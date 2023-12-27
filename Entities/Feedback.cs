using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApi.Entities
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string PhoneNumber { get; set; }
  
        public string? Text { get; set; }

        public string? Files { get; set; }
    }
}
