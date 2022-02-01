using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoExperionWebAPI_1.Models
{
    public class UserModel  //User and Role classses in crm instead
    {
        public  string UserName { get; set; }
        public string  Password { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string Role { get; set; }
    }
}
