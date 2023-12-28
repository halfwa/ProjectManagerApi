using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectManagerApi.Data.Repositories.Implementations;
using ProjectManagerApi.Data.UoW;
using ProjectManagerApi.Dtos.Employees.Positions;
using ProjectManagerApi.Models.Employees;

namespace ProjectManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PositionsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetPositions()
        {
            var repository = _unitOfWork.GetRepository<Position>() as PositionsRepository;

            var positionItems = await repository.GetPositionsAsync();
            if (positionItems.IsNullOrEmpty())
            {
                return NotFound("Not Found!");
            }

            return Ok(_mapper.Map<IEnumerable<PositionReadDto>>(positionItems));
        }

        [HttpGet("{id}", Name = "GetPositionById")]
        public async Task<IActionResult> GetPositionById(int id)
        {
            var repository = _unitOfWork.GetRepository<Position>() as PositionsRepository;
            var positionItem = await repository.GetPositionByIdAsync(id);

            if (positionItem == null)
            {
                return NotFound("Not Found!");
            }

            return Ok(_mapper.Map<PositionReadDto>(positionItem));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePosition(PositionCreateDto positionCreateDto)
        {
            var repository = _unitOfWork.GetRepository<Position>() as PositionsRepository;

            var positionExist = await repository.GetPositionByTitleAsync(positionCreateDto.Title);
            if (positionExist != null)
            {
                return Conflict("Conflict!");
            }

            var positionModel = _mapper.Map<Position>(positionCreateDto);
            var result = await repository.CreatePositionAsync(positionModel);
            if (!result)
            {
                return BadRequest("BadRequest!");
            }

            var positionReadDto = _mapper.Map<PositionReadDto>(positionModel);
            return CreatedAtRoute(nameof(GetPositionById), new { Id = positionReadDto.Id }, positionReadDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePosition(
            int id,
            [FromBody] PositionUpdateDto positionUpdateDto)
        {
            var repository = _unitOfWork.GetRepository<Position>() as PositionsRepository;

            var position = await repository.GetPositionByIdAsync(id);
            if (position == null)
            {
                return NotFound("Not Found!");
            }

            var positionExist = await repository.GetPositionByTitleAsync(positionUpdateDto.Title);
            if (positionExist != null)
            {
                return Conflict("Conflict!");
            }

            var result = await repository.UpdatePositionAsync(position, positionUpdateDto);
            if (!result)
            {
                return BadRequest("BadRequest!");
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePositions()
        {
            var repository = _unitOfWork.GetRepository<Position>() as PositionsRepository;

            var positionItems = await repository.GetPositionsAsync();
            if (!positionItems.Any())
            {
                return NotFound("Not Found!");
            }

            var result = await repository.DeletePositionsAsync();
            if (!result)
            {
                return StatusCode(500, "Error deleting projects");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosition(int id)
        {
            var repository = _unitOfWork.GetRepository<Position>() as PositionsRepository;

            var positionItem = await repository.GetPositionByIdAsync(id);
            if (positionItem == null)
            {
                return NotFound("Not Found!");
            }

            var result = await repository.DeletePositionAsync(positionItem);

            if (!result)
            {
                return StatusCode(500, "Error deleting projects");
            }

            return NoContent();
        }
    }
}
