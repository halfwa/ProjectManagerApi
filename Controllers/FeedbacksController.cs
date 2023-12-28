using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerApi.Data.UoW;
using ProjectManagerApi.Dtos;
using ProjectManagerApi.Entities;
using ProjectManagerApi.Filters;
using ProjectManagerApi.Services;

namespace ProjectManagerApi.Controllers
{
    [ExceptionHandler]
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmailRequest _email;

        public FeedbacksController(IEmailRequest email, IMapper mapper)
        {
            _mapper = mapper;
            _email = email;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest(FeedbackCreateDto feedbackCreateDto)
        {
            if (feedbackCreateDto == null) return BadRequest();

            if (feedbackCreateDto.Name == null ||
                feedbackCreateDto.PhoneNumber == null)
            {
                return BadRequest();
            }

            var feedback = _mapper.Map<Feedback>(feedbackCreateDto);
            _email.SendMessageAsync(feedback);
            return Ok();
        }
    }
}
