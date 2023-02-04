using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NFLPlayerReview.Dto;
using NFLPlayerReview.Interfaces;
using NFLPlayerReview.Models;
using SQLitePCL;

namespace NFLPlayerReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NFLPositionController : Controller
    {
        private readonly INFLPositionRepository _positionRepository;
        private readonly IMapper _mapper;
        public NFLPositionController(INFLPositionRepository positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<NFLPosition>))]
        public IActionResult GetNFLPlayers()
        {
            var positions = _mapper.Map<List<NFLPositionDto>>(_positionRepository.GetNFLPositions());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(positions);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<NFLPosition>))]
        [ProducesResponseType(400)]
        public IActionResult GetNFLPositionByID(int id)
        {
            if (!_positionRepository.NFLPositionExists(id))
            {
                return NotFound();
            }

            var position = _mapper.Map<NFLPositionDto>(_positionRepository.GetNFLPositionByID(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(position);
        }

        [HttpGet("player/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<NFLPosition>))]
        [ProducesResponseType(400)]
        public IActionResult GetNFLPlayerByPosition(int positionId)
        {
            var player = _mapper.Map<List<NFLPlayerDto>>(_positionRepository.GetNFLPlayerByPosition(positionId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(player);
        }
    }
}
