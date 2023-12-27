using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApi.Models.Employees
{
    [Index("Title", IsUnique = true)]
    public class Position
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }

        public string? Description { get; set; }

        public Employee Employee { get; set; }
    }
}
