        using AutoMapper;
using HRMS.Data;
using HRMS.DTO;
using HRMS.Migrations;
using HRMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly HRMSDbContext context;

        private readonly IMapper mapper;

        public LeaveController(HRMSDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> GetLeave()
        {
            var data = await context.Leave.ToListAsync();
            return Ok(data);
        }


        [HttpPost]
        public async Task<ActionResult> PostLeave(LeaveDTO leave)
        {

            var model = mapper.Map<Leave>(leave);
            await context.Leave.AddAsync(model);
            await context.SaveChangesAsync();
            return Ok(leave);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLeave(int id, LeaveDTO leavedto)
        {
            var upd = await context.Leave.FindAsync(id);
            if (id == 0)
            {
                return BadRequest();
            }


            upd.isFullDay = leavedto.isFullDay;
            upd.isMultipleDay  = leavedto.isMultipleDay;    
            upd.FromDate = leavedto.FromDate;
            upd.ToDate = leavedto.ToDate;   
            upd.Reason = leavedto.Reason;   
            context.Leave.Update(upd);  
            await context.SaveChangesAsync();
            return Ok(leavedto);


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<LeaveDTO>> DeleteLeave(int id)
        {
            var del = await context.Leave.FindAsync(id);
            if (del == null)
            {
                return NotFound(id);
            }
            context.Leave.Remove(del);
            await context.SaveChangesAsync();
            return Ok(del);
        }

    }
}

