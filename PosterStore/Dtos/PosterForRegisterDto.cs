using System.Collections.Generic;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PosterStore.Dtos
{
    public class PosterForRegisterDto
    {
        public string Size { get; set; }
        public string Description { get; set; }
        [Required]
        public string Title { get; set; }
        public string Price { get; set; }
        public List<IFormFile> Photos { get; set; }

    }
}