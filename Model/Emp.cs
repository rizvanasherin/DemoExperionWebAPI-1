using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoExperionWebAPI_1.Model
{
    public class Emp
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public string Department { get; set; }
        public string Contact { get; set; }
        public Boolean IsActive { get; set; }
    }
}
