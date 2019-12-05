using Data;
using PagedList;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ActivityManagerController : Controller
    {

        serviceprojet ac = new projetService();
        activityInterface sc = new ActivityService();
        // GET: Activity

        public ActionResult Index()
        {
            var activityms = new List<activitym>();
            foreach (activity pdomain in sc.GetMany())
            {
                activityms.Add(new activitym()
                {
                    id = pdomain.id,
                    nom = pdomain.nom,
                    description = pdomain.description,
                    
                    NombreHeuresEstimer = pdomain.NombreHeuresEstimer,
                    NombreHeuresTravailler = pdomain.NombreHeuresTravailler,
                    statut = pdomain.statut,
                    projet_id = pdomain.projet_id,
                //    user_idUser = 1


                });

            }


            return View(activityms);
        }
        public ActionResult IndexEmploye()
        {
            var activityms = new List<activitym>();
            foreach (activity pdomain in sc.GetMany())
            {
                activityms.Add(new activitym()
                {
                    id = pdomain.id,
                    nom = pdomain.nom,
                    description = pdomain.description,

                    NombreHeuresEstimer = pdomain.NombreHeuresEstimer,
                    NombreHeuresTravailler = pdomain.NombreHeuresTravailler,
                    statut = pdomain.statut,
                    projet_id = pdomain.projet_id,
                    //    user_idUser = 1


                });

            }


            return View(activityms);
        }
        public ActionResult GetData()
        {
            Context context = new Context();

            var query = context.activities.Include("projet_id")
                   .GroupBy(p => p.projet_id)
                   .Select(g => new { name = g.Key, count = g.Sum(w => w.NombreHeuresEstimer) }).ToList();
            return Json(query, JsonRequestBehavior.AllowGet);
        }


        public ActionResult IndexTri(string sortOrder, string CurrentSort, int? page)
        {
            Context db = new Context();
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewBag.CurrentSort = sortOrder;
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "nom" : sortOrder;
            IPagedList<activity> activities = null;
            switch (sortOrder)
            {
                case "nom":
                    if (sortOrder.Equals(CurrentSort))
                        activities = db.activities.OrderByDescending
                                (m => m.nom).ToPagedList(pageIndex, pageSize);
                    else
                        activities = db.activities.OrderBy
                                (m => m.nom).ToPagedList(pageIndex, pageSize);
                    break;
                case "projet_id":
                    if (sortOrder.Equals(CurrentSort))
                        activities = db.activities.OrderByDescending
                                (m => m.projet_id).ToPagedList(pageIndex, pageSize);
                    else
                        activities = db.activities.OrderBy
                                (m => m.projet_id).ToPagedList(pageIndex, pageSize);
                    break;
                case "statut":
                    if (sortOrder.Equals(CurrentSort))
                        activities = db.activities.OrderByDescending
                                (m => m.statut).ToPagedList(pageIndex, pageSize);
                    else
                        activities = db.activities.OrderBy
                                (m => m.statut).ToPagedList(pageIndex, pageSize);
                    break;
                case "datedebut":
                    if (sortOrder.Equals(CurrentSort))
                        activities = db.activities.OrderByDescending
                                (m => m.datedebut).ToPagedList(pageIndex, pageSize);
                    else
                        activities = db.activities.OrderBy
                                (m => m.datedebut).ToPagedList(pageIndex, pageSize);
                    break;
                case "dateFin":
                    if (sortOrder.Equals(CurrentSort))
                        activities = db.activities.OrderByDescending
                                (m => m.dateFin).ToPagedList(pageIndex, pageSize);
                    else
                        activities = db.activities.OrderBy
                                (m => m.dateFin).ToPagedList(pageIndex, pageSize);
                    break;
                case "NombreHeuresEstimer":
                    if (sortOrder.Equals(CurrentSort))
                        activities = db.activities.OrderByDescending
                                (m => m.NombreHeuresEstimer).ToPagedList(pageIndex, pageSize);
                    else
                        activities = db.activities.OrderBy
                                (m => m.NombreHeuresEstimer).ToPagedList(pageIndex, pageSize);
                    break;
                case "NombreHeuresTravailler":
                    if (sortOrder.Equals(CurrentSort))
                        activities = db.activities.OrderByDescending
                                (m => m.NombreHeuresTravailler).ToPagedList(pageIndex, pageSize);
                    else
                        activities = db.activities.OrderBy
                                (m => m.NombreHeuresTravailler).ToPagedList(pageIndex, pageSize);
                    break;
                case "description":
                    if (sortOrder.Equals(CurrentSort))
                        activities = db.activities.OrderByDescending
                                (m => m.description).ToPagedList(pageIndex, pageSize);
                    else
                        activities = db.activities.OrderBy
                                (m => m.description).ToPagedList(pageIndex, pageSize);
                    break;
                case "Default":
                    activities = db.activities.OrderBy
                        (m => m.projet_id).ToPagedList(pageIndex, pageSize);
                    break;
            }
            return View(activities);
        }


       

        // GET: Activity/Details/5
        public ActionResult Details(int id)
        {
            var c = sc.GetById(id);

            activitym d = new activitym();

            d.id = c.id;
            d.nom = c.nom;
            d.description = c.description;
            d.statut = c.statut;
            d.NombreHeuresTravailler = c.NombreHeuresTravailler;
            d.NombreHeuresEstimer = c.NombreHeuresEstimer;
           // d.NombreHeuresEnRetard = c.NombreHeuresEnRetard;


            return View(d);

        }

        // GET: Activity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Activity/Create
        [HttpPost]
        public ActionResult Create(activitym collection)
        {
            activity c = new activity();


            c.id = collection.id;
            c.nom = collection.nom;
            c.description = collection.description;
            c.NombreHeuresEstimer = collection.NombreHeuresEstimer; ;

            c.statut = collection.statut;

            c.projet_id = collection.projet_id;
            c.user_idUser = 1;
           

            //   c.mailClient = collection.mailClient;




            sc.Add(c);
            sc.Commit();
            //   return View();
            return RedirectToAction("Index");
        }

        // GET: Activity/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Activity/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, activitym ord)
        {
            try
            {

                activity order = sc.GetById(id);
                order.nom = ord.nom;
                order.description = ord.description;
               // order.mailClient = ord.mailClient;
                order.NombreHeuresEstimer =ord.NombreHeuresEstimer;
                order.statut = ord.statut;
                 order.projet_id = ord.projet_id;

                //    order.NombreHeuresTravailler = ViewBag.total2;



                sc.Update(order);
                sc.Commit();


                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditEmploye(int id)
        {
            return View();
        }

        // POST: Activity/Edit/5
        [HttpPost]
        public ActionResult EditEmploye(int id, activitym ord)
        {
            try
            {

                activity order = sc.GetById(id);
                //  order.nom = ord.nom;
                //  order.description = ord.description;
                // order.mailClient = ord.mailClient;
                order.datedebut = ord.datedebut;
                order.dateFin = ord.dateFin;
                order.NombreHeuresTravailler = ord.NombreHeuresTravailler;
                order.statut = ord.statut;
              //  order.projet_id = ord.projet_id;

                //    order.NombreHeuresTravailler = ViewBag.total2;



                sc.Update(order);
                sc.Commit();


                // TODO: Add update logic here

                return RedirectToAction("IndexEmploye");
            }
            catch
            {
                return View();
            }
        }
        // GET: Activity/Delete/5
        public ActionResult Delete(int id)
        {
            activity c = sc.GetById(id);

            sc.Delete(c);
            sc.Commit();
            return RedirectToAction("Index");
        }

        // POST: Activity/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
