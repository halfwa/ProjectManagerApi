using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerApi.Data.Repositories.Implementations;
using ProjectManagerApi.Data.Repository;
using ProjectManagerApi.Data.UoW;
using ProjectManagerApi.Dtos.Projects;
using ProjectManagerApi.Models.Projects;


namespace ProjectManagerApi.Controllers
{
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
            var projectItems = await repository.GetProjectsAsync();

            return Ok(projectItems);
        }

        [HttpGet("{id}", Name = "GetProjectById")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var repository = _unitOfWork.GetRepository<Project>() as ProjectsRepository;
            var projectItem =  await repository.GetProjectByIdAsync(id);

            if (projectItem != null)
            {
                return Ok(_mapper.Map<ProjectReadDto>(projectItem));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(ProjectCreateDto createProjectDto)
        {
            var projectModel = _mapper.Map<Project>(createProjectDto);

            var repository = _unitOfWork.GetRepository<Project>() as ProjectsRepository;
            await repository.CreateProjectAsync(projectModel);

            var projectReadDto = _mapper.Map<ProjectReadDto>(projectModel);

           return CreatedAtRoute(nameof(GetProjectById), new { Id = projectReadDto.Id }, projectReadDto);
        }
    }
}