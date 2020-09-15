using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ClientApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientApplication.Controllers
{
    public class SchoolWebApi
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44352/");

            return client;
        }
    }
    public class StudentClientController : Controller
    {
        // GET: StudentClient
        SchoolWebApi api = new SchoolWebApi();

        [HttpGet]
        public ActionResult Index()
        {
            List<StudentViewModel> schools = new List<StudentViewModel>();
            using (var client = api.Initial())
            {

                //HTTP GET
                var responseTask = client.GetAsync("api/Students");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<List<StudentViewModel>>();
                    readTask.Wait();

                    schools = readTask.Result;



                }
                return View(schools);
            }
        }
        // GET: StudentClient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentClient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentClient/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentClient/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentClient/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentClient/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentClient/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
