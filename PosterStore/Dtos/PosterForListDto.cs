using System.Collections.Generic;
using PosterStore.Models;

namespace PosterStore.Dtos
{
    public class PosterForListDto
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public string PhotoUrl { get;set;}
        
    }
}