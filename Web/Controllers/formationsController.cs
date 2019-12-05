using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;

using System.Web.Mvc;
using Data;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Linq;
using System.IO;

namespace Web.Controllers
{
    public class formationsController : Controller
    {
        private PidevContext db = new PidevContext();

        // GET: formations
        public ActionResult Index()
        {

            return View();
        }
       
        public ActionResult Indexx()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("UserManager-web/rest/formation/all").Result;
            if (response.IsSuccessStatusCode)
            {
                 ViewBag.result = response.Content.ReadAsAsync<IEnumerable<formation>>().Result;
                
            }
            else
            {
                ViewBag.result = "error";
            }
            return View(ViewBag.result);
        }
        [HttpPost]
        public ActionResult filtrer(string categorie)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("UserManager-web/rest/formation/all").Result;
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<formation> fs = response.Content.ReadAsAsync<IEnumerable<formation>>().Result;
                
                return View("Indexx", fs.ToList().FindAll(f => f.categorie == categorie).ToList());

            }
            else
            {
                ViewBag.result = "error";
            }
            return this.RedirectToAction("Indexx");
        }

        // GET: formations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            formation formation = db.formation.Find(id);
            if (formation == null)
            {
                return HttpNotFound();
            }
            return View(formation);
        }

        // GET: formations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: formations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFormation,DateDebutF,DateFinF,Formateur,NomF,skillsF_idSkills,categorie")] formation formation)
        {
            if (ModelState.IsValid)
            {
          
                string url = "http://localhost:9080/UserManager-web/rest/formation/add/" + 
                    formation.DateFinF.Value.ToString("yyyy-MM-dd") + "/" +
                    formation.DateDebutF.Value.ToString("yyyy-MM-dd") + "/"
                    + formation.categorie + "/"
                    + formation.Formateur + "/" 
                    + formation.NomF;
                HttpClient Client = new HttpClient();
         
                Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = Client.GetAsync(url).Result;



                return RedirectToAction("Indexx");
            }

            return View(formation);
        }

        // GET: formations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            formation formation = db.formation.Find(id);
            if (formation == null)
            {
                return HttpNotFound();
            }
            return View(formation);
        }

        // POST: formations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFormation,DateDebutF,DateFinF,Formateur,NomF,skillsF_idSkills,categorie")] formation formation)
        {
            if (ModelState.IsValid)
            {
             /*   try
                {*/

              string url = "http://localhost:9080/UserManager-web/rest/formation/update/" +
        formation.DateFinF.Value.ToString("yyyy-MM-dd") + "/" +
        formation.DateDebutF.Value.ToString("yyyy-MM-dd") + "/"
        + formation.categorie + "/"
        + formation.Formateur + "/"
        + formation.NomF + "/" + formation.idFormation;
                HttpClient Client = new HttpClient();

                Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = Client.GetAsync(url).Result;
                return RedirectToAction("Indexx");
             //   }
            /*   catch
                {
                    return View("error");
                }*/



            }
            return View(formation);
        }

        // GET: formations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.DeleteAsync("UserManager-web/rest/formation/delete/"+id).Result;
            if (response.IsSuccessStatusCode)
            {
                return this.RedirectToAction("Indexx");
            }
           
            return this.RedirectToAction("Indexx");
        }

        // POST: formations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            formation formation = db.formation.Find(id);
            db.formation.Remove(formation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
