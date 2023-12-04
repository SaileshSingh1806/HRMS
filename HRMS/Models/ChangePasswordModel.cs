using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HRMS.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Old Password is required")]
        public string oldPassword { get; set; }

        [Required(ErrorMessage = "New Password is required")]
        public string newPassword { get; set; }

        //[Required(ErrorMessage = "ConfirmNew Password is required")]
        //public string confirmnewPassword { get; set; }
    }
}
