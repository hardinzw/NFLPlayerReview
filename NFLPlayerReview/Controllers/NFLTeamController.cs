using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NFLPlayerReview.Dto;
using NFLPlayerReview.Interfaces;
using NFLPlayerReview.Models;

namespace NFLPlayerReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NFLTeamController : Controller
    {
        private readonly INFLTeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public NFLTeamController(INFLTeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<NFLTeam>))]
        public IActionResult GetNFLTeams()
        {
            var teams = _mapper.Map<List<NFLTeamDto>>(_teamRepository.GetNFLTeams());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(teams);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<NFLTeam>))]
        [ProducesResponseType(400)]
        public IActionResult GetNFLTeamByID(int id)
        {
            if (!_teamRepository.NFLTeamExists(id))
            {
                return NotFound();
            }

            var team = _mapper.Map<NFLTeamDto>(_teamRepository.GetNFLTeamByID(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(team);
        }

        [HttpGet("{teamID}/player")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<NFLTeam>))]
        [ProducesResponseType(400)]
        public IActionResult GetNFLPlayerByTeam(int teamID)
        {
            if (!_teamRepository.NFLTeamExists(teamID))
            {
                return NotFound();
            }

            var team = _mapper.Map<List<NFLPlayerDto>>(_teamRepository.GetNFLPlayerByTeam(teamID));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(team);
        }

        [HttpGet("{playerID}/team")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<NFLTeam>))]
        [ProducesResponseType(400)]
        public IActionResult GetNFLTeamByPlayer(int playerID)
        {
            if (!_teamRepository.NFLTeamExists(playerID))
            {
                return NotFound();
            }

            var player = _mapper.Map<List<NFLTeamDto>>(_teamRepository.GetNFLTeamByPlayer(playerID));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(player);
        }
    }
}
