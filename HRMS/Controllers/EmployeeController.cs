using AutoMapper;
using HRMS.Data;
using HRMS.DTO;
using HRMS.Migrations;
using HRMS.Models;
using HRMS.Repository.Interface;
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
        private readonly IEmployee employeerepo;
        public EmployeeController(HRMSDbContext context,IMapper mapper, IEmployee employeerepo)
        {
            this.context = context;
            this.mapper = mapper;
            this.employeerepo = employeerepo;   

        }

        [HttpGet]
        public async Task <List<Employee>> GetEmployee()
        {
            var data = await employeerepo.GetEmployee();
            return data;
        }

        [HttpPost]
        public async Task<ActionResult> PostEmployee(EmpDTO emp)
        {
            var model = mapper.Map<Employee>(emp);
            await employeerepo.PostEmployee(model); 
            return Ok(model);   
           
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
        
        
        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdateEmployee(int id,EmpDTO emp)
        //{
        //    //var data = await context.Employees.FindAsync(id);
        //    //if (id != data.Id)
        //    //{ var    
        //    //    return BadRequest();
        //    //}
        //    //var model = mapper.Map<Employee>(emp);  
        //    //context.Entry(model).State = EntityState.Modified;
        //    //return Ok(model);

        //}
       
        
        [HttpDelete("{id}")]

        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var emp = await employeerepo.DeleteEmployee(id);
            if (emp)
            {
                return Ok(emp);
            }
            return NotFound();
           

        }
    }
}
