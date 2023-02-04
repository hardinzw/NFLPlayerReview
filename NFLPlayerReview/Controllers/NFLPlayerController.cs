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
        private readonly IMapper _mapper;

        public NFLPlayerController(INFLPlayerRepository nFLPlayerRepository, IMapper mapper)
        {
            _playerRepository = nFLPlayerRepository;
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
    }
}
