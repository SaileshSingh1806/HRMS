using HRMS.Models;
using System.ComponentModel.DataAnnotations;

namespace HRMS.DTO
{
    public class LeaveDTO
    {
        public bool isFullDay { get; set; }

        public bool isMultipleDay { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public string Reason { get; set; }

        public IEnumerable<LeaveRequestDTO> LeaveRequests { get; set; }

    }


}
    


