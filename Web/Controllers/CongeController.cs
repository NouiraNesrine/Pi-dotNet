using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Service;


namespace Web.Controllers
{
    public class CongeController : Controller
    {
        PidevContext db = new PidevContext();
        public CongeService cs;
        public CongeController()
        {
            cs = new CongeService();
        }

        // GET: Conge
        public ActionResult Index()
        {
            return View(cs.GetAll());
        }

        // GET: Conge/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            conge conge = cs.GetById(id);
            if (conge == null)
            {
                return HttpNotFound();
            }
            return View(conge);
        }

        // GET: Conge/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conge/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(conge conge)
        {
            cs.Add(conge);
            cs.Commit();
               
                return RedirectToAction("Index");
          
        }

       

        // GET: Conge/Delete/5
        static int ide;
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            conge conge = cs.GetById(id);
            ide = id;
            if (conge == null)
            {
                return HttpNotFound();
            }
            return View(conge);
        }

        // POST: Conge/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAction()
        {
            conge conge = cs.GetById(ide);
            cs.Delete(conge);
            cs.Commit();
            //return RedirectToAction("Index");    
            return RedirectToAction("Index");
        }

       
    }
}
