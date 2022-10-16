using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class EmpClass
    {
        public long EmployeeId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Required")]
        [MinLength(11,ErrorMessage ="MobileNumber no should be 11 digit")]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required")]
        public string HomeAddress { get; set; }
        [Required(ErrorMessage = "Required")]
        public DateTime DateOfJoin { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Country { get; set; }
        public string Hobbies { get;set; }

    }
}