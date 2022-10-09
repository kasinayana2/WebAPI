using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;
using System.Net.Http;

namespace WebAPI.Controllers
{
    public class CrudController : Controller
    {
        // GET: Crud
        public ActionResult Index()
        {
            IEnumerable<tblEmployee> empobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44302/api/EmpCrud");

            var consumeapi = hc.GetAsync("EmpCrud");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<tblEmployee>>();
                displaydata.Wait();

                empobj = displaydata.Result;
            }
            return View(empobj);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tblEmployee insertemp)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44302/api/EmpCrud");

            var insertrecord = hc.PostAsJsonAsync<tblEmployee>("EmpCrud", insertemp);
            insertrecord.Wait();

            var savedata = insertrecord.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public ActionResult details(int id)
        {
            EmpClass empobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44302/api/");

            var consumeapi = hc.GetAsync("EmpCrud/" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<EmpClass>();
                displaydata.Wait();
                empobj = displaydata.Result;
            }
            return View(empobj);
        }
        public ActionResult edit(int id)
        {
            EmpClass empobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44302/api/");

            var consumeapi = hc.GetAsync("EmpCrud/" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<EmpClass>();
                displaydata.Wait();
                empobj = displaydata.Result;
            }
            return View(empobj);

        }
        [HttpPost]
        public ActionResult edit(EmpClass ec)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44302/api/EmpCrud");
            var insertrecord = hc.PutAsJsonAsync<EmpClass>("EmpCrud",ec);
            insertrecord.Wait();

            var savedata = insertrecord.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Employee Record Not Updated...!";
            }
            return View(ec);


        }

        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44302/api/EmpCrud");

            var delrecord = hc.DeleteAsync("EmpCrud/" + id.ToString());
            delrecord.Wait();

            var displaydata = delrecord.Result;
            if(displaydata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
    
}