using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApi.Entities
{
    [Index(nameof(Name), nameof(Link), IsUnique = true)]
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public required string Link { get; set; }

        public string? Image { get; set; }
    }
}
