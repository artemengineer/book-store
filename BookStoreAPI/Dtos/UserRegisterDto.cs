using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Dtos
{
    public class UserRegisterDto
    {
        [Required] public string Username { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 3, ErrorMessage = "You must specify password between 3 and 6 characters")]
        public string Password { get; set; }
    }
}