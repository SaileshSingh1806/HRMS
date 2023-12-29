using HRMS.Authentication;

namespace HRMS.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public string? UserId { get; set; }
        public string? Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BloodGroup { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? MobileNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string? Organization { get; set; }
        public string? Role { get; set; }
        public string? Designation { get; set; }
        public string? AssignedManager { get; set; }
        public string? Status { get; set; }
        public DateTime? ActiveForm { get; set; }
     
    }
}
