using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoExperionWebAPI_1.Models;
using DemoExperionWebAPI_1.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoExperionWebAPI_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository; //abstraction

        //constructor injection
        public EmployeesController(IEmployeeRepository employeeRepository) //encapsulation
        {
            _employeeRepository = employeeRepository; 
        }

        #region Get All Employees
        [HttpGet]
      //  [Authorize]
      //  [Authorize(AuthenticationSchemes ="Bearer")] //use this if the above one is not working
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesAll()
        {
            return await _employeeRepository.GetAllEmployees();
        }

        #endregion
        #region Add Employee
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            //check the validation of body
            if(ModelState.IsValid)
            {
                try
                {
                 var employeeId  = await _employeeRepository.AddEmployee(employee);
                    if(employeeId >0)
                    {
                        return Ok(employeeId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch(Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Update an Employee

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeRepository.UpdateEmployee(employee);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region find an employee by id

        //Endpoint:https://localhost:44360/api/employee/3
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>>GetEmployeeById(int? id)
        {
            try
            {
                var employee = await _employeeRepository.GetEmployeeById(id);
                if(employee == null)
                {
                    return NotFound();
                }
                return employee;  //return ok();
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region delete an employee
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteEmployeeById(int? id)
        {
            int result = 0;
            if(id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _employeeRepository.DeleteEmployee(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();  //return ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
