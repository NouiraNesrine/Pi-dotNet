using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Data;
using Service;

namespace Web.Controllers
{
    public class StatuController : Controller
    {
        PidevContext db = new PidevContext();
        public StatuService ss;
        public StatuController()
        {
            ss = new StatuService();
        }

        // GET: Statu
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9082");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("/UserManager-web/rest/statu").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<statu>>().Result;
            }
            return View();
        }

        // GET: Statu/Details/5
        /*  public ActionResult Details(int? id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              statu statu = db.status.Find(id);
              if (statu == null)
              {
                  return HttpNotFound();
              }
              return View(statu);
          }

          // GET: Statu/Create
          public ActionResult Create()
          {
              return View();
          }
          */
        // POST: Statu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public int Create(string subject)
        {
            statu s = new statu();
            s.description = subject;
            ss.Add(s);
            ss.Commit();
            return 1;

        }
        /*
        // GET: Statu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            statu statu = db.status.Find(id);
            if (statu == null)
            {
                return HttpNotFound();
            }
            return View(statu);
        }
        */
        // POST: Statu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       
        public int Edit(String statu,int id)
        {
            statu s = ss.GetById(id);
            s.description = statu;
            /* ss.Update(s);
             ss.Commit();*/
            db.Entry(s).State = EntityState.Modified;
            db.SaveChanges();
            return 1;

        }
        /*
        // GET: Statu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            statu statu = db.status.Find(id);
            if (statu == null)
            {
                return HttpNotFound();
            }
            return View(statu);
        }
        */
        // POST: Statu/Delete/5
        [HttpPost]
        public int DeleteSt(int id)
        {
            statu s = ss.GetById(id);
            ss.Delete(s);
            ss.Commit();
            return 1;
        }
        /*
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
