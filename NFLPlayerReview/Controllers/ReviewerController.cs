using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NFLPlayerReview.Dto;
using NFLPlayerReview.Interfaces;
using NFLPlayerReview.Models;
using NFLPlayerReview.Repository;

namespace NFLPlayerReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : Controller
    {
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IMapper _mapper;
        public ReviewerController(IReviewerRepository reviewerRepository, IMapper mapper)
        {
            _reviewerRepository = reviewerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
        public IActionResult GetReviews()
        {
            var reviewers = _mapper.Map<List<ReviewerDto>>(_reviewerRepository.GetReviewers());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(reviewers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
        public IActionResult GetReviewerByID(int id)
        {
            if (!_reviewerRepository.ReviewerExists(id))
            {
                return NotFound();
            }

            var reviewer = _mapper.Map<ReviewerDto>(_reviewerRepository.GetReviewerByID(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(reviewer);
        }

        [HttpGet("reviewer/{reviewerID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
        public IActionResult GetReviewsByReviewer(int reviewerID)
        {
            if (!_reviewerRepository.ReviewerExists(reviewerID))
            {
                return NotFound();
            }

            var reviewer = _mapper.Map<List<ReviewDto>>(_reviewerRepository.GetReviewsByReviewer(reviewerID));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(reviewer);
        }
    }
}
