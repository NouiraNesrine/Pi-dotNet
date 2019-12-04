using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PiNet.web.Models;
using PiNet.service;
using PiNet.domain.Entities;

namespace PiNet.web.Controllers
{
    public class ExpenseNoteController : Controller
    {
        public MissionService missionService ;
        public TrspExpService trspExpService ;
        public MissExpService missExpService ;
        public ExpNoteService expNoteService ;
        public RestExpService restExpService ;
        public AccExpService accExpService ;
        public OtherExpService otherExpService ;
        User u ;

        public ExpenseNoteController()
        {
            missionService = new MissionService();
            trspExpService = new TrspExpService();
            missExpService = new MissExpService();
            expNoteService = new ExpNoteService();
            restExpService = new RestExpService();
            accExpService = new AccExpService();
            otherExpService = new OtherExpService();

            u = new User { idUser = 1, Firstname = "aa", Lastname = "aa", isActiv = true, email = "aa", password = "aa", role = "employe" };

        }
        // GET: ExpenseNote
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("UserManager-web/ApiJavaEE/Mission/Aproved").Result;
            ICollection<MissionModel> list = new HashSet<MissionModel>();
            foreach (var item in response.Content.ReadAsAsync<IEnumerable<MissionModel>>().Result)
            {
                foreach (var it in item.participants)
                {
                    if (it.idUser==u.idUser)
                    {
                        list.Add(item);
                    }
                }

            }
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = list;
            }
            else
            {
                ViewBag.result = "error";
            }


            return View();
        }
       

        // GET: ExpenseNote/Details/5
        public ActionResult createExpenseNote(int id)
        {
          /*  
            if (ms.GetAll() == null)
            {
                return HttpNotFound();
            }*/
            return null;
            
        }
        public ActionResult AddAccExp(int id )
        {

            ViewData["id"] = id ;
            ViewBag.accType = new SelectList(Enum.GetValues(typeof(AccType)));
            return View();

        }
        [HttpPost]
        public ActionResult AddAccExp(AccommodationExpenses accxp, HttpPostedFileBase file)
        {
            AccommodationExpenses acc = new AccommodationExpenses();
            acc.acctype = Request["acctype"];
            acc.duration = accxp.duration;
           
                acc.idFoodIncluded = accxp.idFoodIncluded;
            
           
            acc.costs = accxp.costs;
            acc.accommodationBill = file.FileName;
            
            ExpenseNote ex = new ExpenseNote();
                ex = expNoteService.GetById(accxp.id);
            ex.totalCost = ex.totalCost + acc.costs;
            ex.accommodationexpenses.Add(acc);
            expNoteService.Update(ex);
            expNoteService.Commit();
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
        public ActionResult AddRestExp(int id)
        {
            ViewData["id"] = id;
            return View();

        }
        [HttpPost]
        public ActionResult AddRestExp(RestaurationModel rest)
        {
            RestaurationExpenses rxp = new RestaurationExpenses();
            rxp.costs = rest.costs;
            rxp.restaurationBill = rest.restaurationBill;
            ExpenseNote ex = new ExpenseNote();
            ex = expNoteService.GetById(rest.id);
            ex.restaurationexpenses.Add(rxp);
            expNoteService.Update(ex);
            expNoteService.Commit();

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
        public ActionResult AddTrspExp(int id)
        {
            /*  
              if (ms.GetAll() == null)
              {
                  return HttpNotFound();
              }*/
            return null;

        }
        public ActionResult AddOtherExp(int id)
        {
            /*  
              if (ms.GetAll() == null)
              {
                  return HttpNotFound();
              }*/
            return null;

        }
        // GET: ExpenseNote/createNote/5
        public ActionResult createNote(int id)
        {
            //get Mission
            Mission m = missionService.GetById(id);

            //get or create ExpenseNote
            ExpenseNote expense = null;
            foreach (var iexp in expNoteService.GetAll())
            {
                if(iexp.mission_refrence==m.refrence && iexp.employee_idUser==u.idUser )
                {
                    expense = iexp;
                }

            }
            if (expense==null)
            {
                expense = new ExpenseNote() { date = DateTime.Now, isApproved = false, employee_idUser = u.idUser, totalCost = 0, totalRecovered = 0, mission_refrence = m.refrence };
            }
            
            //get or create MissionExpense
            MissionExpenses missexp = null;
            bool refrence = false;
            bool add = false;
            foreach (var imxp in missExpService.GetAll())
            {
                if (imxp.mission_refrence==m.refrence)
                {
                    missexp = imxp;
                    foreach (var i in missexp.expensenote)
                    {
                        if (i.refrence==expense.refrence)
                        {
                            refrence = true;
                        }
                    }
                    if (refrence==false)
                    {
                        missexp.expensenote.Add(expense);
                        missExpService.Update(missexp);
                    }
                }

            }
            if (missexp==null)
            {
                missexp = new MissionExpenses()
                { mission_refrence = m.refrence, isApproved = false, totalRecovered = 0 };
                missexp.expensenote.Add(expense);
                missExpService.Add(missexp);
            }
            missExpService.Commit();

            ViewData["id"] = expense.refrence;
            ViewBag.acc = expense.accommodationexpenses;
            ViewBag.trs = expense.transportexpenses;
            ViewBag.res = expense.restaurationexpenses;
            ViewBag.oth = expense.otherexpenses;
            return View();
        }


        // GET: ExpenseNote/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExpenseNote/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExpenseNote/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
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

        // GET: ExpenseNote/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExpenseNote/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ExpenseNote/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExpenseNote/Delete/5
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
