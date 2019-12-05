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
    public class ratesController : Controller
    {
        public RateService rs;
        public UserService us;

        public ratesController()
        {
            rs = new RateService();
        }

        // GET: rates
        public ActionResult Index()
        {
            return View(rs.GetAll());
        }

        // GET: rates/Details/5
       public ActionResult Details(int id)
        {
            rate r= rs.GetById(id);
            if (r == null)
            {
                return HttpNotFound();
            }
            return View(r);
        }

        // GET: rates/Create
        public ActionResult Create()
        {
            us = new UserService();
            var users = us.GetMany();
            ViewBag.user = new SelectList(users, "idUser", "Lastname");
            return View();
        }

        // POST: rates/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( rate rate)
        {
            rate r = new rate();

            r.user_idUser = rate.user_idUser;
            r.score = rate.score;
     
            rs.Add(r);
            rs.Commit();
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       
        // GET: rates/Edit/5
        public ActionResult Edit(int id)
        {
            //return View(rs.GetById(id));
            us = new UserService();
            var users = us.GetMany();
            ViewBag.user = new SelectList(users, "idUser", "Lastname");
            return View(rs.GetById(id));
        }

        // POST: rates/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, rate rate)
        {
            rate r = new rate();
            // TODO: Add update logic here
            r = rs.GetById(id);
            r.score = rate.score;
            r.user_idUser = rate.user_idUser;
            rs.Update(r);
            rs.Commit();
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View(rate);
            }
        }

        // GET: rates/Delete/5
        public ActionResult Delete(int id)
        {

            rate rate = rs.GetById(id);
             if (rate == null)
            {
                return HttpNotFound();
            }

            return View(rate);

            
        }

        // POST: rates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, rate rate)
        {
           
            try
            {
                // TODO: Add delete logic here
                rate = rs.GetById(id);
                rs.Delete(rate);
                rs.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       /* protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
        
    }

}
