using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApi.Dtos.Projects
{
    public class ProjectUpdateDto   
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        public required string Link { get; set; }

        public required string Image { get; set; }
    }
}
