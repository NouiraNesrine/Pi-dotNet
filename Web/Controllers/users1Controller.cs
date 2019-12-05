using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Data;

namespace Web.Controllers
{
    public class users1Controller : Controller
    {
        public ActionResult Index2()
        {
            return View();
        }
        [HttpPost]
          public ActionResult Index2(user u)
          {
              HttpClient Client = new HttpClient();
              Client.BaseAddress = new Uri("http://localhost:9080");
              Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
              HttpResponseMessage response = Client.GetAsync("UserManager-web/api/users/login?email=" + u.email + "&password=" + u.password).Result;
              if (response.IsSuccessStatusCode)
              {
                  // timesheetService ts;

                  user user = response.Content.ReadAsAsync<user>().Result;
                  Session["id"] = user.idUser;
                  Session["nom"] = user.Lastname;
                  if (user.role.Equals("administrateur"))
                  {

                      // ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Emp>>().Result;
                      return RedirectToAction("Index","Evaluation");
                  }
                  else if(user.role.Equals("employe"))
                  {
                      return RedirectToAction("Index", "rates");
                  }
                else 
                {
                    return RedirectToAction("Error", "Shared");
                }
            }
              else
              {
                  return RedirectToAction("Index2");
              }
          }

       /* // GET: users1
        public ActionResult Index()
        {
            return View(db.user.ToList());
        }

        // GET: users1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.user.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: users1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: users1/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUser,Firstname,Lastname,email,isActiv,password,role")] user user)
        {
            if (ModelState.IsValid)
            {
                db.user.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: users1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.user.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: users1/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUser,Firstname,Lastname,email,isActiv,password,role")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: users1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.user.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: users1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = db.user.Find(id);
            db.user.Remove(user);
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
