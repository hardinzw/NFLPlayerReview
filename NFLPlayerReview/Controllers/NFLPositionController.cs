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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePosition([FromBody] NFLPositionDto positionCreate)
        {
            if (positionCreate == null)
            {
                return BadRequest(ModelState);
            }

            var positions = _positionRepository.GetNFLPositions().Where(p => p.Name.Trim().ToUpper() == positionCreate.Name.TrimEnd().ToUpper()).FirstOrDefault();

            if (positions != null)
            {
                ModelState.AddModelError("", "Position already exists.");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var positionMap = _mapper.Map<NFLPosition>(positionCreate);

            if (!_positionRepository.CreatePosition(positionMap))
            {
                ModelState.AddModelError("", "Something went wrong...");
                return StatusCode(500, ModelState);
            }

            return Ok("Position successuflly created.");
        }
    }
}
