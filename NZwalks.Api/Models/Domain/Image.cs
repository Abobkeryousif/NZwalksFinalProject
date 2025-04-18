﻿using System.ComponentModel.DataAnnotations.Schema;

namespace NZwalks.Api.Models.Domain
{
    public class Image
    {
        public Guid Id { get; set; }

        [NotMapped]
        public IFormFile file { get; set; }

        public string FileName { get; set; }
        public string? FileDescription { get; set; }
        public string FileExtension { get; set; }

        public long SizeInBytes { get; set; }

        public string FilePath { get; set; }
    }
}
