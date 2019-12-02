using System.ComponentModel.DataAnnotations;
namespace PosterStore.Dtos
{
    public class PosterForRegisterDto
    {
        public string Size { get; set; }
        public string Description { get; set; }
        [Required]
        public string Title { get; set; }
        public string Price { get; set; }
    }
}