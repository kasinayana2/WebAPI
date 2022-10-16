using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class GenderController : ApiController
    {
        EmployeeEntities cs = new EmployeeEntities();

        [HttpGet]
        public IHttpActionResult GetAllGender()
        {
            var results = cs.tblGenders.ToList();
            return Ok(results);
        }
    }
}
