using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApi.Dtos
{
    public class FeedbackCreateDto
    {
        public required string Name { get; set; }

        public required string PhoneNumber { get; set; }

        public string? Text { get; set; }

        public string? Files { get; set; }
    }
}
