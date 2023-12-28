using ProjectManagerApi.Models.Employees;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApi.Dtos.Employees.Positions
{
    public class PositionCreateDto
    {
        public required string Title { get; set; }

        public string? Description { get; set; }

    }
}
