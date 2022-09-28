using System.ComponentModel.DataAnnotations;

namespace WebChuyenDe.Data.ViewModel
{
    public class UserLoginViewModel
    {
        [Required]
        [StringLength(256, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 3)]
        public string Password { get; set; }
    }
}