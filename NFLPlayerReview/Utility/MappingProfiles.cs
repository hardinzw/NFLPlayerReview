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
            CreateMap<NFLPositionDto, NFLPosition>();
            CreateMap<NFLDivision, NFLDivisionDto>();
            CreateMap<NFLDivisionDto, NFLDivision>();
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>();
            CreateMap<Reviewer, ReviewerDto>();
            CreateMap<ReviewerDto, Reviewer>();
        }
    }
}
