using HRMS.DTO;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Leave
    {
        [Key]
        public int Id { get; set; }

        public bool isFullDay { get; set; }

        public bool isMultipleDay { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public string Reason { get; set; }

        public ICollection<LeaveRequest> LeaveRequests { get; set; }

    }
}
