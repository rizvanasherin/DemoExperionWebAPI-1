using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoExperionWebAPI_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoExperionWebAPI_1.Repository
{
    public interface IEmployeeRepository    
    {
        //Get all employees       --SELECT / RETRIEVE
        //Asynchronous  --async --await --promise
        Task<List<Employee>> GetAllEmployees();

        //Add an employee  --INSERT(SQL)/CREATE(IN CRUD)
        Task<int> AddEmployee(Employee employee);

        //Update an employee  --UPDATE
        Task UpdateEmployee(Employee employee);

        //Delete an employee
        Task<int> DeleteEmployee(int? id);

        //get an employee by id
        Task<ActionResult<Employee>> GetEmployeeById(int? id);

    }
}
