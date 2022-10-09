using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class EmpClass
    {
        public long EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string HomeAddress { get; set; }

    }
}