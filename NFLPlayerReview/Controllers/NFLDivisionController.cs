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
        [ProducesResponseType(200, Type = typeof(IEnumerable<NFLTeam>))]
        public IActionResult GetNFLDivisions()
        {
            var divisions = _mapper.Map<List<NFLDivsionDto>>(_divisionRepository.GetNFLDivisions());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(divisions);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<NFLTeam>))]
        [ProducesResponseType(400)]
        public IActionResult GetNFLDivisionByID(int id)
        {
            if (!_divisionRepository.NFLDivisionExists(id))
            {
                return NotFound();
            }

            var division = _mapper.Map<NFLTeamDto>(_divisionRepository.GetNFLDivisionByID(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(division);
        }
    }
}
