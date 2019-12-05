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
    public class QuizController : Controller
    {
        public QuizService qs;
        public QuizController()
        {
            qs = new QuizService();
        }
        // GET: Quiz
        public ActionResult Index()
        {
            return View(qs.GetAll());
        }

        // GET: Quiz/Details/5
        public ActionResult Details(long id)
        {

            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quiz quiz = qs.GetById(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // GET: Quiz/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quiz/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateI(quiz quiz)
        {

            qs.Add(quiz);
            qs.Commit();
            return RedirectToAction("Index");


        }

        // GET: Quiz/Edit/5
        public ActionResult Edit(long id)
        {
            quiz quiz = qs.GetById(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }

            return View(quiz);
        }

        // POST: Quiz/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditI(quiz q)
        {
            
            qs.UpdateQuiz(q);
            qs.Commit();
            return RedirectToAction("Index");

 }
        
         // GET: Quiz/Delete/5
         public ActionResult Delete(int id)
         {
             if (id == 0)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
            quiz quiz = qs.GetById(id);
             if (quiz == null)
             {
                 return HttpNotFound();
             }
             return View(quiz);
         }

         // POST: Quiz/Delete/5
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public ActionResult DeleteConfirmed(int id)
         {
            quiz quiz = qs.GetById(id);
            qs.Delete(quiz);
            qs.Commit();
             return RedirectToAction("Index");
         }
        public ActionResult PasserQuizInex()
        {
            return View();
        }
        public ActionResult Evaluate(Categorie categorie)
        {
            List<quiz> list = qs.GetMany(e => e.categorie == categorie).ToList();
            if (list.Count == 0)
                return View("Error");
            Random rnd = new Random();
            int index = rnd.Next(list.Count);
            return View(list[index]);
        }
        [HttpPost]
        public ActionResult Evaluate(int idq, string rep1, string rep2, string rep3)
        {
            quiz q = qs.GetMany(e => e.Idq == idq).FirstOrDefault();
            float point = (20 / 3);
            float note = 0;
            note = q.r1j.Equals(rep1) ? (note + point) : note;
            note = q.r2j.Equals(rep2) ? (note + point) : note;
            note = q.r3j.Equals(rep3) ? (note + point) : note;
            return RedirectToAction("Note", new { note });
        }
        public ActionResult Note(float note)
        {
            ViewBag.note = note;
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            user e = qs.login(email, password);
            if (e == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Session["user"] = e;
            if (e.role == "administrateur")
                return RedirectToAction("Indexx","formations");
            else
                return RedirectToAction("PasserQuizInex");

        }
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}
