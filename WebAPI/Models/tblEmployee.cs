//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblEmployee
    {
        public long EmployeeId { get; set; }
        [Required(ErrorMessage = "FirstName Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "MobileNumber Required")]
        [MinLength(10, ErrorMessage = "MobileNumber no should be 10 digit")]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "HomeAddress Required")]
        public string HomeAddress { get; set; }
        [Required(ErrorMessage = "DateOfJoin Required")]
        public Nullable<System.DateTime> DateOfJoin { get; set; }
        [Required(ErrorMessage = "Gender Required")]
        public Nullable<int> GenderId { get; set; }
        [Required(ErrorMessage = "Country Required")]
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> HobbyId { get; set; }
    
        public virtual tblCountry tblCountry { get; set; }
        public virtual tblGender tblGender { get; set; }
        public virtual tblHobby tblHobby { get; set; }
    }
}