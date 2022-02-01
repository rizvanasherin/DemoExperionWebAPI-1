using System;
using System.Collections.Generic;

namespace DemoExperionWebAPI_1.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public DateTime? DateofJoining { get; set; }
        public string Contact { get; set; }
        public string Department { get; set; }
    }
}
