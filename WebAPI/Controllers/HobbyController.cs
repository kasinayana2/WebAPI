using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class HobbyController : ApiController
    {
        EmployeeEntities cs = new EmployeeEntities();

        [HttpGet]
        public IHttpActionResult GetAllHobby()
        {
            var results = cs.tblHobbies.ToList();
            return Ok(results);
        }
    }
}
