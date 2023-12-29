using HRMS.Authentication;
using HRMS.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.DTO
{
    public class LeaveRequestDTO
    {

       
        public int LeaveId { get; set; }
        public string RequestedBy { get; set; }

        public DateTime AppliedDate { get; set; }

        public string AppliedTo { get; set; }

        public Status Status { get; set; }
       
    }
}
