using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoExperionWebAPI_1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoExperionWebAPI_1.Controllers   //localhost:44306/api/emps
{
    [Route("api/[controller]")]
    [ApiController]         //Annotation
    public class EmpsController : ControllerBase
    {
        //without database ---retrieve data from Dictionary or List
        List<Emp> employeeList = new List<Emp>()
        {
            //Anonymous
            new Emp()
            {
                EmployeeId =1,
                EmployeeName ="Risvana",
                Designation= "SoftwareEngineering",
                DateOfJoining= DateTime.Parse("01-01-2020"),
                Contact ="9747240955",
                Department="IT"
            },
            new Emp()
            {
                EmployeeId =2,
                EmployeeName ="Sarah",
                Designation= "Team Lead",
                DateOfJoining= DateTime.Parse("08-06-2020"),
                Contact ="8590424203",
                Department="Support"
            },
            new Emp()
            {
                EmployeeId =3,
                EmployeeName ="Akash",
                Designation= "Quality Analyst",
                DateOfJoining= DateTime.Parse("11-07-2020"),
                Contact ="9526659526",
                Department="QA"
            }
        };
        //Creating endpoint  --OK or Error result   
        #region 

        [HttpGet]
        public IActionResult  GetEmployeeList()
        {
            if(employeeList.Count==0)
            {
                return NotFound("No items in the List found");
            }
            return Ok(employeeList);
        }



        #endregion
    }
}
