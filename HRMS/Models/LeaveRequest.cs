using HRMS.Authentication;
using System.ComponentModel.DataAnnotations;  
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Models
{
    public class LeaveRequest
    {
        [Key]
        public int Id { get; set; }

        public Leave Leave { get; set; }
        public int LeaveId { get; set; }

        public ApplicationUser Requested { get; set; }
        [ForeignKey("Requested")]
        public string RequestedBy { get; set; }

        public DateTime AppliedDate { get; set; }

        public ApplicationUser Applied { get; set; }
        [ForeignKey("Applied")]
        public string AppliedTo { get; set; }

        public Status Status { get; set; }

        public ApplicationUser Approved { get; set; }
        [ForeignKey("Approved")]
        public string? ApprovedBy { get; set; }

        public DateTime? ApprovedDate { get; set; }
    }

    public enum Status
    {
        Pending,
        Accepted,
        Rejected,
        Deleted 
    }

}
