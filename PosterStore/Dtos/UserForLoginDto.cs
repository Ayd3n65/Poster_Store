namespace PosterStore.Dtos
{
    public class UserForLoginDto
    {
        //  [Required]
        public string Username { get; set; }
        // [Required]
        // [StringLength(8,MinimumLength=4,ErrorMessage="Определите пароль между 4 и 8 символами")]
        public string Password { get; set; } 
    }
}