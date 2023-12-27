using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApi.Dtos.Projects
{
    public class ProjectCreateDto
    {
        [Required]
        public required string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public required string Link { get; set; }

        public string? Image { get; set; }
    }
}
