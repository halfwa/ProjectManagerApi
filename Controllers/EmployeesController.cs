using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectManagerApi.Data.Repositories.Implementations;
using ProjectManagerApi.Data.UoW;
using ProjectManagerApi.Dtos.Employees;
using ProjectManagerApi.Dtos.Services;
using ProjectManagerApi.Entities;
using ProjectManagerApi.Models.Employees;

namespace ProjectManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var repository = _unitOfWork.GetRepository<Employee>() as EmployeesRepository;

            var employees = await repository.GetEmployeesAsync();
            if (employees.IsNullOrEmpty())
            {
                return NotFound("Not Found!"); 
            }

            return Ok(_mapper.Map<IEnumerable<EmployeeReadDto>>(employees));
        }

        [HttpGet("{id}", Name = "GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var repository = _unitOfWork.GetRepository<Employee>() as EmployeesRepository;
            var employee = await repository.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return NotFound("Not Found!");
            }

            return Ok(_mapper.Map<EmployeeReadDto>(employee));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeCreateDto employeeCreateDto)
        {
            var repository = _unitOfWork.GetRepository<Employee>() as EmployeesRepository;

            var employeeModel = _mapper.Map<Employee>(employeeCreateDto);
            var result = await repository.CreateEmployeeAsync(employeeModel);
            if (!result)
            {
                return BadRequest("BadRequest!");
            }

            var employeeReadDto = _mapper.Map<EmployeeReadDto>(employeeModel);
            return CreatedAtRoute(nameof(GetEmployeeById), new { Id = employeeReadDto.Id }, employeeReadDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(
            int id,
            [FromBody] EmployeeUpdateDto employeeUpdateDto)
        {
            var repository = _unitOfWork.GetRepository<Employee>() as EmployeesRepository;

            var employee = await repository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound("Not Found!");
            }

            var result = await repository.UpdateEmployeeAsync(employee, employeeUpdateDto);
            if (!result)
            {
                return BadRequest("BadRequest!");
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployees()
        {
            var repository = _unitOfWork.GetRepository<Employee>() as EmployeesRepository;

            var employees = await repository.GetEmployeesAsync();
            if (!employees.Any())
            {
                return NotFound("Not Found!");
            }

            var result = await repository.DeleteEmployeesAsync();
            if (!result)
            {
                return StatusCode(500, "Error deleting projects");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var repository = _unitOfWork.GetRepository<Employee>() as EmployeesRepository;

            var employee = await repository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound("Not Found!");
            }

            var result = await repository.DeleteEmployeeAsync(employee);
            if (!result)
            {
                return StatusCode(500, "Error deleting projects");
            }

            return NoContent();
        }
    }
}
