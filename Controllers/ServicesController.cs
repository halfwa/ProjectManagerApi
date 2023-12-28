using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectManagerApi.Data.Repositories.Implementations;
using ProjectManagerApi.Data.UoW;
using ProjectManagerApi.Dtos.Projects;
using ProjectManagerApi.Dtos.Services;
using ProjectManagerApi.Entities;
using ProjectManagerApi.Filters;

namespace ProjectManagerApi.Controllers
{
    [ExceptionHandler]
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServicesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetServices()
        {
            var repository = _unitOfWork.GetRepository<Service>() as ServicesRepository;
            var serviceItems = await repository.GetServicesAsync();

            if (serviceItems.IsNullOrEmpty())
            {
                return NotFound("Not Found!");
            }

            return Ok(_mapper.Map<IEnumerable<ServiceReadDto>>(serviceItems));
        }

        [HttpGet("{id}", Name = "GetServiceById")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var repository = _unitOfWork.GetRepository<Service>() as ServicesRepository;
            var serviceItem = await repository.GetServiceByIdAsync(id);

            if (serviceItem == null)
            {
                return NotFound("Not Found!");
            }

            return Ok(_mapper.Map<ServiceReadDto>(serviceItem));
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(ServiceCreateDto serviceCreateDto)
        {
            var repository = _unitOfWork.GetRepository<Service>() as ServicesRepository;

            var serviceExist = await repository.GetServiceByNameAsync(serviceCreateDto.Name);
            if (serviceExist != null)
            {
                return Conflict("Conflict!");
            }

            var serviceModel = _mapper.Map<Service>(serviceCreateDto);
            var result = await repository.CreateServiceAsync(serviceModel);
            if (!result)
            {
                return BadRequest("BadRequest!");
            }

            var serviceReadDto = _mapper.Map<ServiceReadDto>(serviceModel);
            return CreatedAtRoute(nameof(GetServiceById), new { Id = serviceReadDto.Id }, serviceReadDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(
            int id,
            [FromBody] ServiceUpdateDto serviceUpdateDto)
        {
            var repository = _unitOfWork.GetRepository<Service>() as ServicesRepository;

            var service = await repository.GetServiceByIdAsync(id);
            if (service == null)
            {
                return NotFound("Not Found!");
            }

            var serviceExist = await repository.GetServiceByNameAsync(serviceUpdateDto.Name);
            if (serviceExist != null)
            {
                return Conflict("Conflict!");
            }

            var result = await repository.UpdateServiceAsync(service, serviceUpdateDto);
            if (!result)
            {
                return BadRequest("BadRequest!");
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteServices()
        {
            var repository = _unitOfWork.GetRepository<Service>() as ServicesRepository;

            var projectItems = await repository.GetServicesAsync();
            if (!projectItems.Any())
            {
                return NotFound("Not Found!");
            }

            var result = await repository.DeleteServicesAsync();
            if (!result)
            {
                return StatusCode(500, "Error deleting projects");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var repository = _unitOfWork.GetRepository<Service>() as ServicesRepository;
            var serviceItem = await repository.GetServiceByIdAsync(id);

            if (serviceItem == null)
            {
                return NotFound("Not Found!");
            }

            var result = await repository.DeleteServiceAsync(serviceItem);

            if (!result)
            {
                return StatusCode(500, "Error deleting projects");
            }

            return NoContent();
        }
    }
}
