using HRMS.DTO;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Repository.Interface
{
    public interface IEmployee
    {

        Task<List<Employee>> GetEmployee();

        Task<Employee> PostEmployee(Employee emp);

        Task<List<Employee>> GetEmployeeById(int id);

        Task<bool> DeleteEmployee(int id);


    }
}
