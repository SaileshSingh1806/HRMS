using AutoMapper;
using HRMS.Data;
using HRMS.DTO;
using HRMS.Migrations;
using HRMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {

        private readonly HRMSDbContext context;

        private readonly IMapper mapper;

        public LeaveRequestController(HRMSDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]

        public async Task<ActionResult> GetLeaveRequest()
        {
            var data = await context.LeaveRequest.Include(x => x.Requested).ToListAsync();
            var usersReadDto = mapper.Map<List<LeaveRequestDTO>>(data);
            return Ok(usersReadDto);
        }

        
    }
        
}