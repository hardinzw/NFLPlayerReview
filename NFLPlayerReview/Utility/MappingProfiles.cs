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
            CreateMap<NFLTeam, NFLTeamDto>();
            CreateMap<NFLPosition, NFLPositionDto>();
            CreateMap<NFLDivision, NFLDivsionDto>();
        }
    }
}
