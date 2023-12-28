using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApi.Dtos.Services
{
    public class ServiceReadDto
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public required string Image { get; set; }
    }
}
