
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
       /*
        public ActionResult Index()
        {
            return View();
        }

       public ActionResult Login()
        {
            return View();
        }
        public ActionResult LoggedIn(user u)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9082");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("UserManager-web/rest/login?email=" + u.email + "&password=" + u.password).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Login");
        }
        
        public ActionResult Register(user u)
        {
            HttpClient Client1 = new HttpClient();
            Client1.BaseAddress = new Uri("http://localhost:9082");
            Client1.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response1 = Client1.GetAsync("UserManager-web/rest/register").Result;
            if (response1.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Register");
            }
        }*/
    }
}