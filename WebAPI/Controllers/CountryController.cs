using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class CountryController : ApiController
    {
        EmployeeEntities cs = new EmployeeEntities();

        [HttpGet]
        public IHttpActionResult GetAllCountry()
        {
            var results = cs.tblCountries.ToList();
            return Ok(results);
        }
    }

}
