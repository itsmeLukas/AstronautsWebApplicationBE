﻿using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace AstronautsWebApplication.Models
{
    public class Astronaut
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required DateTime BirthDate { get; set; }
        public required string Superpower { get; set; }
    }
}
