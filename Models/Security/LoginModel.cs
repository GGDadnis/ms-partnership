using System.ComponentModel.DataAnnotations;

namespace ms_partnership.Models.Security
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Login need to have username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Login need to have password")]
        public string Password { get; set; }
    }
}