﻿namespace NZwalks.Api.Models.DTO
{
    public class WalkDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public double LengthInKm { get; set; }

        public string? WalkIamgeUrl { get; set; }

        public RegionDTO Region { get; set; }
        public DifficultyDTO Difficulty { get; set; }
    }
}
