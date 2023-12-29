using HRMS.Data;
using HRMS.DTO;
using HRMS.Models;
using HRMS.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly HRMSDbContext context;

        public EmployeeRepository(HRMSDbContext context)
        {
            this.context = context;
        }


        public async Task<bool> DeleteEmployee(int id)
        {
            var emp = await context.Employees.FindAsync(id);
            if (emp != null) 
            
            {
                context.Employees.Remove(emp);
                await context.SaveChangesAsync();
                return true;
            }

            return false;


        }

        public async Task<List<Employee>> GetEmployee()
        {
            var data = await context.Employees.ToListAsync();
            return data;
        }   

        public Task<List<Employee>> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> PostEmployee(Employee emp)
        {
            await context.Employees.AddAsync(emp);
            await context.SaveChangesAsync();
            return emp;
        }


  
    }
}
