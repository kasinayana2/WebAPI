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
            ViewBag.genList = GetGenderList();
            ViewBag.conList = GetCountryList();
            ViewBag.hobList = GetHobbyList();
            return View();
        }

        private List<SelectListItem> GetGenderList()
        {
            IEnumerable<tblGender> genList = new List<tblGender>();
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44302/api/Gender");

            var consumeapi = hc.GetAsync("Gender");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<tblGender>>();
                displaydata.Wait();

                genList = displaydata.Result;
            }


            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (var gender in genList)
            {
                SelectListItem sl = new SelectListItem();
                sl.Value = Convert.ToString(gender.GenderId);
                sl.Text = gender.GenderName;
                selectList.Add(sl);
            }

            return selectList;
        }
        private List<SelectListItem> GetCountryList()
        {
            IEnumerable<tblCountry> conList = new List<tblCountry>();
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44302/api/Country");

            var consumeapi = hc.GetAsync("Country");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<tblCountry>>();
                displaydata.Wait();

                conList = displaydata.Result;
            }


            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (var country in conList)
            {
                SelectListItem sl = new SelectListItem();
                sl.Value = Convert.ToString(country.CountryId);
                sl.Text = country.CountryName;
                selectList.Add(sl);
            }

            SelectListItem samplesl = new SelectListItem();
            samplesl.Value = "0";
            samplesl.Text = "Please select country";
            samplesl.Selected = true;
            selectList.Add(samplesl);
            return selectList;
        }

        private List<SelectListItem> GetHobbyList()
        {
            IEnumerable<tblHobby> hobList = new List<tblHobby>();
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44302/api/Hobby");

            var consumeapi = hc.GetAsync("Hobby");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<tblHobby>>();
                displaydata.Wait();

                hobList = displaydata.Result;
            }


            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (var hobby in hobList)
            {
                SelectListItem sl = new SelectListItem();
                sl.Value = Convert.ToString(hobby.HobbyId);
                sl.Text = hobby.HobbyName;
                selectList.Add(sl);
            }

            SelectListItem samplesl = new SelectListItem();
            samplesl.Value = "0";
            samplesl.Text = "Please select hobby";
            samplesl.Selected = true;
            selectList.Add(samplesl);
            return selectList;
        }



        [HttpPost]
        public ActionResult Create(tblEmployee insertemp)
        {
            if (ModelState.IsValid)
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
                return View();
            }
            else
            {

                ViewBag.genList = GetGenderList();
                ViewBag.conList = GetCountryList();
                ViewBag.hobList = GetHobbyList();
                return View();
            }
        }

        public ActionResult details(int id)
        {
            tblEmployee empobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44302/api/");

            var consumeapi = hc.GetAsync("EmpCrud/" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<tblEmployee>();
                displaydata.Wait();
                empobj = displaydata.Result;
            }
            return View(empobj);
        }
        public ActionResult edit(int id)
        {
            tblEmployee empobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44302/api/");

            var consumeapi = hc.GetAsync("EmpCrud/" + id.ToString());
            consumeapi.Wait();
            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<tblEmployee>();
                displaydata.Wait();
                empobj = displaydata.Result;
            }
            ViewBag.genList = GetGenderList();
            ViewBag.conList = GetCountryList();
            ViewBag.hobList = GetHobbyList();
            return View(empobj);
        }
        [HttpPost]
        public ActionResult edit(tblEmployee ec)
        {
            if (ModelState.IsValid)
            {
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44302/api/EmpCrud");
                var insertrecord = hc.PutAsJsonAsync<tblEmployee>("EmpCrud", ec);
                insertrecord.Wait();
                var savedata = insertrecord.Result;
                if (savedata.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.genList = GetGenderList();
                ViewBag.conList = GetCountryList();
                ViewBag.hobList = GetHobbyList();
                ViewBag.message = "tblEmployee Record Not Updated...!";
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