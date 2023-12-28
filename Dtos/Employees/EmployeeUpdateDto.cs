using ProjectManagerApi.Models.Employees;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApi.Dtos.Employees
{
    public class EmployeeUpdateDto
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Patronymic { get; set; }

        public required string Photo { get; set; }

        public required int PositionId { get; set; }

    }
}
