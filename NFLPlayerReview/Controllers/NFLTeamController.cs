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
        private readonly INFLDivisionRepository _divisionRepository;
        private readonly IMapper _mapper;

        public NFLTeamController(INFLTeamRepository teamRepository, INFLDivisionRepository divisionRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _divisionRepository = divisionRepository;
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateTeam([FromQuery] int divisionID, [FromBody] NFLTeamDto teamCreate)
        {
            if (teamCreate == null)
            {
                return BadRequest(ModelState);
            }

            var teams = _teamRepository.GetNFLTeams().Where(t => t.Name.Trim().ToUpper() == teamCreate.Name.TrimEnd().ToUpper()).FirstOrDefault();

            if (teams != null)
            {
                ModelState.AddModelError("", "Team already exists.");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teamMap = _mapper.Map<NFLTeam>(teamCreate);
            teamMap.Division = _divisionRepository.GetNFLDivisionByID(divisionID);

            if (!_teamRepository.CreateTeam(teamMap))
            {
                ModelState.AddModelError("", "Something went wrong...");
                return StatusCode(500, ModelState);
            }

            return Ok("Team created.");
        }

        [HttpPut("{teamID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePosition(int teamID, [FromBody] NFLTeamDto teamUpdate)
        {
            if (teamUpdate == null)
            {
                return BadRequest(ModelState);
            }

            if (teamID != teamUpdate.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_teamRepository.NFLTeamExists(teamID))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teamMap = _mapper.Map<NFLTeam>(teamUpdate);

            if (!_teamRepository.UpdateTeam(teamMap))
            {
                ModelState.AddModelError("", "Something went wrong...");
                return StatusCode(500, ModelState);
            }

            return Ok("Team successuflly updated.");
        }
    }
}
