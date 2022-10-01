using System.ComponentModel.DataAnnotations;

namespace Saitynai_Delivery_System1.DTOs
{
    public class UserDto
    {
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [StringLength(30, MinimumLength = 9)]
        public string Password { get; set; } = string.Empty;
    }
}
