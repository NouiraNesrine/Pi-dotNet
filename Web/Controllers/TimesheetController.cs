using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class TimesheetController : Controller
    {
        // GET: Timesheet
        public ActionResult Index()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/piConsom-web/activator/timesheet").Result;
            if (response.IsSuccessStatusCode)
            {
                ICollection<timesheetm> listtest = new List<timesheetm>();
                IEnumerable<timesheetm> testViewModel = response.Content.ReadAsAsync<IEnumerable<timesheetm>>().Result;
                foreach (timesheetm programmeViewModel in testViewModel)
                {

                    timesheetm prog = new timesheetm();

                    prog.id = programmeViewModel.id;
                    prog.NombreHeureTravailler = programmeViewModel.NombreHeureTravailler;

                    prog.NombreJoursTravaillerParmois = programmeViewModel.NombreJoursTravaillerParmois;

                    prog.isActive = programmeViewModel.isActive;
                    prog.LastClockOut = programmeViewModel.LastClockOut;
                    prog.ClockIn = programmeViewModel.ClockIn;



                    listtest.Add(prog);
                }
                ViewBag.result = listtest;
            }
            else
            {
                ViewBag.result = "erreur";
            }
            return View();
        }

        // GET: Timesheet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Timesheet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Timesheet/Create
        [HttpPost]
        public ActionResult Create(timesheet domain)
        {
            {

                HttpClient Client = new HttpClient();

                HttpResponseMessage response = Client.PostAsJsonAsync<timesheet>(" http://localhost:9080/piConsom-web/activator/timesheet", domain)
                    .ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode()).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            //   catch
            {
                return View();
            }
        }

        // GET: Timesheet/Edit/5
        public ActionResult Edit(int id)
        {
            timesheetm topic = null;

            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:9080/piConsom-web/activator/timesheet/out" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                topic = response.Content.ReadAsAsync<timesheetm>().Result;

            }

            else
            {
                ViewBag.result = "error";
            }

            return View(topic);
        
        }

        // POST: Timesheet/Edit/5
        [HttpPost]
        public ActionResult Edit( timesheetm t)
        {
            try
            {

                HttpClient Client = new HttpClient();
                HttpResponseMessage response = Client.PutAsJsonAsync<timesheetm>("http://localhost:9080/piConsom-web/activator/timesheet/out", t).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode()).Result;

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Timesheet/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/piConsom-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/activator/timesheet/supprimer/" + id).Result;
            timesheetm domain = new timesheetm();
            if (response.IsSuccessStatusCode)
            {

                domain = response.Content.ReadAsAsync<timesheetm>().Result;

            }
            else
            {
                ViewBag.project = "erreur";
            }

            return View(domain);
        }

        // POST: Domain/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            try
            {
                // TODO: Add delete logic here
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9080/piConsom-web/");

                // TODO: Add insert logic here
                client.DeleteAsync("activator/timesheet/supprimer/" + id)
                        .ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
