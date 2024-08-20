using System.ComponentModel.DataAnnotations;

namespace AstronautsWebApplication.Models
{
    public class Astronaut
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public required string Surname { get; set; }
        [Required]
        public required DateTime BirthDate { get; set; }
        [Required]
        public required string Superpower { get; set; }

    }
}
