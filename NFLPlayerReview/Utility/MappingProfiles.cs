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
            CreateMap<NFLPosition, NFLPositionDto>();
            CreateMap<NFLDivision, NFLDivisionDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<Reviewer, ReviewerDto>();
        }
    }
}
