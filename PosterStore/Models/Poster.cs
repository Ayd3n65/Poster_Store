using System.Collections.Generic;

namespace PosterStore.Models
{
    public class Poster
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
         public ICollection<PosterImage> PosterImages { get; set; }

    }
}