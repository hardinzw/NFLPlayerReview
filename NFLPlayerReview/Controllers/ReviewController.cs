using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NFLPlayerReview.Dto;
using NFLPlayerReview.Interfaces;
using NFLPlayerReview.Models;

namespace NFLPlayerReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewController(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public IActionResult GetReviews()
        {
            var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviews());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(reviews);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public IActionResult GetReviewByID(int id)
        {
            if (!_reviewRepository.ReviewExists(id))
            {
                return NotFound();
            }

            var reviews = _mapper.Map<ReviewDto>(_reviewRepository.GetReviewByID(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(reviews);
        }

        [HttpGet("player/{playerID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public IActionResult GetReviewsOfPlayer(int playerID)
        {
            if (!_reviewRepository.ReviewExists(playerID))
            {
                return NotFound();
            }

            var playerReviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviewsOfPlayer(playerID));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(playerReviews);
        }
    }
}
