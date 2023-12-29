namespace HRMS.Models
{
    public class ResetPasswordConfirmModel
    {
        public string Email { get; set; }
        public string ResetToken { get; set; }
        public string NewPassword { get; set; }
    }
}
