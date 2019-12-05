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
    public class decisionsController : Controller
    {
        public DecisionService ds;
        public UserService us;
        public ESHService es;

        public decisionsController()
        {
            ds = new DecisionService();
            es = new ESHService();
        }

        // GET: decisions
        public ActionResult Index()
        {
            IEnumerable<evaluationsheet> ESHByUser;
            IEnumerable<decision> decisions;
            IEnumerable<decision> Newdecisions;
            decisions = ds.GetAll();

          foreach (var d in decisions)
            {
                decision des = new decision();
                des = ds.GetById(d.idDecision);
                int? id = des.evaluationsheet.First().user_idUser;
                ESHByUser = es.GetESHById(id);
               
                float rate;
                rate = ESHByUser.First().rate;
                float scoreFinal=0;
                scoreFinal = rate;
                scoreFinal += des.score;
                des.scoreFinal = scoreFinal/2;
                ds.Update(des);
                ds.Commit();
            }

            Newdecisions = ds.GetAll();
            ViewBag.result = Newdecisions;
  
            return View(ViewBag.result);
}


        // GET: decisions/Details/5
        public ActionResult Details(int id)
        {
            decision d = ds.GetById(id);
            if (d == null)
            {
                return HttpNotFound();
            }
            return View(d);
        }
        /*  // GET: decisions/Create
          public ActionResult Create()
          {
              ViewBag.decisionRef_idDecRef = new SelectList(db.decisionreference, "idDecRef", "idDecRef");
              return View();
          }

          // POST: decisions/Create
          // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
          // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Create([Bind(Include = "idDecision,dateCreationDec,score,typeDec,decisionRef_idDecRef")] decision decision)
          {
              if (ModelState.IsValid)
              {
                  db.decision.Add(decision);
                  db.SaveChanges();
                  return RedirectToAction("Index");
              }

              ViewBag.decisionRef_idDecRef = new SelectList(db.decisionreference, "idDecRef", "idDecRef", decision.decisionRef_idDecRef);
              return View(decision);
          }*/

          // GET: decisions/Edit/5
          public ActionResult Edit(int id)
          {
            return View(ds.GetById(id));
        }

          // POST: decisions/Edit/5
          // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
          // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Edit(int id, decision decision)
          {

            decision d = new decision();
                // TODO: Add update logic here
               d = ds.GetById(id);
            d.score = decision.score;
            d.typeDec = decision.typeDec;
                ds.Update(d);
                 ds.Commit();
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View(decision);
            }
        }

       /*   // GET: decisions/Delete/5
          public ActionResult Delete(int? id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              decision decision = db.decision.Find(id);
              if (decision == null)
              {
                  return HttpNotFound();
              }
              return View(decision);
          }

          // POST: decisions/Delete/5
          [HttpPost, ActionName("Delete")]
          [ValidateAntiForgeryToken]
          public ActionResult DeleteConfirmed(int id)
          {
              decision decision = db.decision.Find(id);
              db.decision.Remove(decision);
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
          }*/
    }
}
