using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EmpCrudController : ApiController
    {
        empcs cs = new empcs();

        [HttpGet]
        public IHttpActionResult getemp()
        {
            var results = cs.tblEmployees.ToList();
            return Ok(results);
        }
        [HttpPost]
        public IHttpActionResult empinsert(tblEmployee empinsert)
        {
            cs.tblEmployees.Add(empinsert);
            cs.SaveChanges();
            return Ok();
        }
        
        [HttpGet]
        //[Route("~/Getempid/{id}")]
        public IHttpActionResult Getempid(int id)
        {
            EmpClass empdetails = null;
            empdetails = cs.tblEmployees.Where(x => x.EmployeeId == id).Select(x => new EmpClass()
            {

                EmployeeId = x.EmployeeId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                MobileNumber = x.MobileNumber,
                Gender = x.Gender,
                Email = x.Email,
                HomeAddress = x.HomeAddress
            }).FirstOrDefault<EmpClass>();

            if (empdetails == null)
            {
                return NotFound();
            }
            return Ok(empdetails);
        }
        public IHttpActionResult put(EmpClass ec)
        {
            var updateemp = cs.tblEmployees.Where(x => x.EmployeeId == ec.EmployeeId).FirstOrDefault<tblEmployee>();
            if (updateemp != null)
            {
                updateemp.EmployeeId = ec.EmployeeId;
                updateemp.FirstName = ec.FirstName;
                updateemp.LastName = ec.LastName;
                updateemp.MobileNumber = ec.MobileNumber;
                updateemp.Gender = ec.Gender;
                updateemp.Email = ec.Email;
                updateemp.HomeAddress = ec.HomeAddress;
                cs.SaveChanges();
            }
            else
            {
                return NotFound();

            }
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var empdel = cs.tblEmployees.Where(x => x.EmployeeId == id).FirstOrDefault();
            cs.Entry(empdel).State = System.Data.Entity.EntityState.Deleted;
            cs.SaveChanges();
            return Ok();
        }
    }
}
