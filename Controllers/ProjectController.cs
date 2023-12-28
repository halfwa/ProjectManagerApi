using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectManagerApi.Data.Repositories.Implementations;
using ProjectManagerApi.Data.Repository;
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
    public class ProjectsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var repository = _unitOfWork.GetRepository<Project>() as ProjectsRepository;

            var projects = await repository.GetProjectsAsync();
            if (projects.IsNullOrEmpty())
            {
                return NotFound("Not Found!");
            }

            return Ok(_mapper.Map<IEnumerable<ProjectReadDto>>(projects));
        }

        [HttpGet("{id}", Name = "GetProjectById")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var repository = _unitOfWork.GetRepository<Project>() as ProjectsRepository;
            var project = await repository.GetProjectByIdAsync(id);

            if (project == null)
            {
                return NotFound("Not Found!");
            }

            return Ok(_mapper.Map<ProjectReadDto>(project));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(ProjectCreateDto projectCreateDto)
        {
            var repository = _unitOfWork.GetRepository<Project>() as ProjectsRepository;

            var projectExist = await repository.GetProjectByNameAsync(projectCreateDto.Name);
            var linkExist = await repository.GetProjectByLinkAsync(projectCreateDto.Link);
            if (projectExist != null || linkExist != null)
            {
                return Conflict("Conflict!");
            }

            var projectModel = _mapper.Map<Project>(projectCreateDto);
            var result = await repository.CreateProjectAsync(projectModel);
            if (!result)
            {
                return BadRequest("BadRequest!");
            }

            var projectReadDto = _mapper.Map<ProjectReadDto>(projectModel);
            return CreatedAtRoute(nameof(GetProjectById), new { Id = projectReadDto.Id }, projectReadDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(
            int id,
            [FromBody] ProjectUpdateDto projectUpdateDto)
        {
            var repository = _unitOfWork.GetRepository<Project>() as ProjectsRepository;

            var project = await repository.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound("Not Found!");
            }

            var projectExist = await repository.GetProjectByNameAsync(projectUpdateDto.Name);
            var linkExist = await repository.GetProjectByLinkAsync(projectUpdateDto.Link);
            if (projectExist != null || linkExist != null)
            {
                return Conflict("Conflict!");
            }

            var result = await repository.UpdateProjectAsync(project, projectUpdateDto);
            if (!result)
            {
                return BadRequest("BadRequest!");
            }

            return Ok("Successfully updated!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProjects()
        {
            var repository = _unitOfWork.GetRepository<Project>() as ProjectsRepository;

            var projectItems = await repository.GetProjectsAsync();
            if (!projectItems.Any())
            {
                return NotFound("Not Found!");
            }

            var result =  await repository.DeleteProjectsAsync();
            if (!result)
            {
                return StatusCode(500, "Error deleting projects");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var repository = _unitOfWork.GetRepository<Project>() as ProjectsRepository;
            var projectItem = await repository.GetProjectByIdAsync(id);

            if (projectItem == null)
            {
                return NotFound("Not Found!");
            }

            var result = await repository.DeleteProjectAsync(projectItem);

            if (!result)
            {
                return StatusCode(500, $"Error deleting project id{id}");
            }

            return NoContent();
        }
    }
}