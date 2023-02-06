using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NFLPlayerReview.Dto;
using NFLPlayerReview.Interfaces;
using NFLPlayerReview.Models;
using SQLitePCL;
using System.Collections.Generic;

namespace NFLPlayerReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NFLPlayerController : Controller
    {
        private readonly INFLPlayerRepository _playerRepository;
        private readonly IReviewerRepository _reviewRepository;
        private readonly IMapper _mapper;

        public NFLPlayerController(INFLPlayerRepository playerRepository, IReviewerRepository reviewRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<NFLPlayer>))]
        public IActionResult GetNFLPlayers()
        {
            var players = _mapper.Map<List<NFLPlayerDto>>(_playerRepository.GetNFLPlayers());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(players);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<NFLPlayer>))]
        [ProducesResponseType(400)]
        public IActionResult GetNFLPlayerByID(int id)
        {
            if (!_playerRepository.NFLPlayerExists(id))
            {
                return NotFound();
            }

            var player = _mapper.Map<NFLPlayerDto>(_playerRepository.GetNFLPlayerByID(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(player);
        }

        [HttpGet("{id}/review")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<NFLPlayer>))]
        [ProducesResponseType(400)]
        public IActionResult GetNFLPlayerReview(int id)
        {
            if (!_playerRepository.NFLPlayerExists(id))
            {
                return NotFound();
            }

            var player = _playerRepository.GetNFLPlayerReview(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(player);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePlayer([FromQuery] int teamID, [FromQuery] int positionID, [FromBody] NFLPlayerDto playerCreate)
        {
            if (playerCreate == null)
            {
                return BadRequest(ModelState);
            }

            var player = _playerRepository.GetNFLPlayers().Where(p => p.Name.Trim().ToUpper() == playerCreate.Name.TrimEnd().ToUpper()).FirstOrDefault();

            if (player != null)
            {
                ModelState.AddModelError("", "Player Already Exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var playerMap = _mapper.Map<NFLPlayer>(playerCreate);

            if (!_playerRepository.CreatePlayer(teamID, positionID, playerMap))
            {
                ModelState.AddModelError("", "Something went wrong...");
                return StatusCode(500, ModelState);
            }

            return Ok("Player succesfully created.");
        }

        [HttpPut("{playerID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePlayer(int playerID, [FromQuery] int teamID, [FromQuery] int positionID, [FromBody] NFLPlayerDto playerUpdate)
        {
            if (playerUpdate == null)
            {
                return BadRequest(ModelState);
            }

            if (playerID != playerUpdate.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_playerRepository.NFLPlayerExists(playerID))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var playerMap = _mapper.Map<NFLPlayer>(playerUpdate);

            if (!_playerRepository.UpdatePlayer(teamID, positionID, playerMap))
            {
                ModelState.AddModelError("", "Something went wrong...");
                return StatusCode(500, ModelState);
            }

            return Ok("Player successuflly updated.");
        }

        [HttpDelete("{playerID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeletePlayer(int playerID)
        {
            if (!_playerRepository.NFLPlayerExists(playerID))
            {
                return NotFound();
            }

            var playerToDelete = _playerRepository.GetNFLPlayerByID(playerID);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_playerRepository.DeletePlayer(playerToDelete))
            {
                ModelState.AddModelError("", "Something went wrong...");
                return StatusCode(500, ModelState);
            }

            return Ok("Player successuflly deleted.");
        }
    }
}
