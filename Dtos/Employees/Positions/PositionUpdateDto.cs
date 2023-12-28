using ProjectManagerApi.Models.Employees;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApi.Dtos.Employees.Positions
{
    public class PositionUpdateDto
    {
        public required string Title { get; set; }

        public required string Description { get; set; }
    }
}
