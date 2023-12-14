using AutoMapper;
using HRMS.Data;
using HRMS.DTO;
using HRMS.Migrations;
using HRMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly HRMSDbContext context;
        private readonly IMapper mapper;
        public EmployeeController(HRMSDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployee()
        {
            var data = await context.Employees.ToListAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult> PostEmployee(EmpDTO emp)
        {
            var model = mapper.Map<Employee>(emp);
            await context.Employees.AddAsync(model);
            await context.SaveChangesAsync();
            return Ok(emp);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Employee>>> GetEmployeeById(int id)
        {

            var data = await context.Employees.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        
        
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee emp)
        {
           if (id != emp.Id)
            {
                return BadRequest();
            }
            context.Entry(emp).State = EntityState.Modified;
            return Ok(emp);
        }
       
        
        [HttpDelete("{id}")]

        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var emp = await context.Employees.FindAsync(id);
            if (emp == null)
            {
                return NotFound(id);
            }
            context.Employees.Remove(emp);
            await context.SaveChangesAsync();
            return Ok(emp);
        }
    }
}
