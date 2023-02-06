using AutoMapper;
using NFLPlayerReview.Dto;
using NFLPlayerReview.Models;

namespace NFLPlayerReview.Utility
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<NFLPlayer, NFLPlayerDto>();
            CreateMap<NFLPlayerDto, NFLPlayer>();
            CreateMap<NFLTeam, NFLTeamDto>();
            CreateMap<NFLTeamDto, NFLTeam>();
            CreateMap<NFLPosition, NFLPositionDto>();
            CreateMap<NFLDivision, NFLDivisionDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>();
            CreateMap<Reviewer, ReviewerDto>();
        }
    }
}
