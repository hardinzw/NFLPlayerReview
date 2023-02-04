using Microsoft.EntityFrameworkCore;
using NFLPlayerReview;
using NFLPlayerReview.Data;
using NFLPlayerReview.Interfaces;
using NFLPlayerReview.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<Seed>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<INFLPlayerRepository, NFLPlayerRepository>();
builder.Services.AddScoped<INFLTeamRepository, NFLTeamRepository>();
builder.Services.AddScoped<INFLPositionRepository, NFLPositionRepository>();
builder.Services.AddScoped<INFLDivisionRepository, NFLDivisionRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewerRepository, ReviewerRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("NFLPlayerReviewDB")));

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    SeedData(app);
}

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
