using ProjectManagerApi.Models.Employees;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApi.Dtos.Employees
{
    public class EmployeeCreateDto
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public string? Patronymic { get; set; }

        public string? Photo { get; set; }

        public required int PositionId { get; set; }

    }
}
