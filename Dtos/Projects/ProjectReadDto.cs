﻿using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApi.Dtos.Projects
{
    public class ProjectReadDto
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public required string Link { get; set; }

        public string? Image { get; set; }
    }
}
