using Data;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class EvaluationController : Controller
    {

        // GET: Evaluation
        public ActionResult Index()
        {
            ESHService es = new ESHService();
            RateService rs = new RateService();

            HttpResponseMessage response = null;

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            response =  Client.GetAsync("UserManager-web/api/evaluations").Result;
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<evaluationsheet> results;
                IEnumerable<evaluationsheet> Newresults;
                results = response.Content.ReadAsAsync<IEnumerable<evaluationsheet>>().Result;
               
                IEnumerable<rate> ratesByUser;

                foreach (var Res in results)
                {
                    float rateFinal = 0;

                    evaluationsheet e = new evaluationsheet();
                    e = es.GetById(Res.evalId);
                    ratesByUser = rs.ListRateByUser(e.user_idUser);
                    foreach(var r in ratesByUser)
                    {
                        rateFinal += r.score;
                    }
                    if (rateFinal != 0)
                    {
                        e.rate = rateFinal / ratesByUser.Count();
                    }else
                    {
                        e.rate = 0;
                    }
                    es.Update(e);
                    es.Commit();
                   
                }

                Newresults = es.GetAll();

                ViewBag.result = Newresults;
            }
            else
            {
                ViewBag.result = "index";
            }
            return View(ViewBag.result);

          
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create( evaluationsheet ev)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080");
            client.PostAsJsonAsync<evaluationsheet>("UserManager-web/api/evaluations", ev ).ContinueWith((postTask)=> postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");
        }

        
    }
}