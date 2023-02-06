using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NFLPlayerReview.Dto;
using NFLPlayerReview.Interfaces;
using NFLPlayerReview.Models;

namespace NFLPlayerReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NFLDivisionController : Controller
    {
        private readonly INFLDivisionRepository _divisionRepository;
        private readonly IMapper _mapper;
        public NFLDivisionController(INFLDivisionRepository divisionRepository, IMapper mapper)
        {
            _divisionRepository = divisionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<NFLDivision>))]
        public IActionResult GetNFLDivisions()
        {
            var divisions = _mapper.Map<List<NFLDivisionDto>>(_divisionRepository.GetNFLDivisions());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(divisions);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<NFLDivision>))]
        [ProducesResponseType(400)]
        public IActionResult GetNFLDivisionByID(int id)
        {
            if (!_divisionRepository.NFLDivisionExists(id))
            {
                return NotFound();
            }

            var division = _mapper.Map<NFLDivisionDto>(_divisionRepository.GetNFLDivisionByID(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(division);
        }

        [HttpGet("/teams/{teamID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<NFLDivision>))]
        [ProducesResponseType(400)]
        public IActionResult GetNFLDivisionByTeam(int teamID)
        {
            if (!_divisionRepository.NFLDivisionExists(teamID))
            {
                return NotFound();
            }

            var team = _mapper.Map<NFLDivisionDto>(_divisionRepository.GetNFLDivisionByTeam(teamID));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(team);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDivision([FromBody] NFLDivisionDto divisionCreate)
        {
            if (divisionCreate == null)
            {
                return BadRequest(ModelState);
            }

            var divisions = _divisionRepository.GetNFLDivisions().Where(p => p.Name.Trim().ToUpper() == divisionCreate.Name.TrimEnd().ToUpper()).FirstOrDefault();

            if (divisions != null)
            {
                ModelState.AddModelError("", "Position already exists.");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var divisionMap = _mapper.Map<NFLDivision>(divisionCreate);

            if (!_divisionRepository.CreateDivision(divisionMap))
            {
                ModelState.AddModelError("", "Something went wrong...");
                return StatusCode(500, ModelState);
            }

            return Ok("Division successuflly created.");
        }

        [HttpPut("{divisionID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateDivision(int divisionID, [FromBody] NFLDivisionDto divisionUpdate)
        {
            if (divisionUpdate == null)
            {
                return BadRequest(ModelState);
            }

            if (divisionID != divisionUpdate.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_divisionRepository.NFLDivisionExists(divisionID))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var divisionMap = _mapper.Map<NFLDivision>(divisionUpdate);

            if (!_divisionRepository.UpdateDivision(divisionMap))
            {
                ModelState.AddModelError("", "Something went wrong...");
                return StatusCode(500, ModelState);
            }

            return Ok("Position successuflly updated.");
        }
    }
}
