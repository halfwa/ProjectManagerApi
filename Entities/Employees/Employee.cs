using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagerApi.Models.Employees
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        public string? Patronymic { get; set; }

        public string? Photo { get; set; }

        [Required]
        public required int PositionId { get; set; }

        public Position Position { get; set; }

        public string GetFullName =>
            string.Join(" ", FirstName, LastName, string.IsNullOrEmpty(Patronymic) ? "" : Patronymic);

    }
}
