
using Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
       
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
            HttpResponseMessage response = Client.GetAsync("/UserManager-web/rest/login?email=" + u.email + "&password=" + u.password).Result;
            Debug.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(u.Firstname);
                ViewBag.us = u;
                Session["email"] = u.email;
                Session["password"] = u.password;
                Debug.WriteLine("Dkhaaaaaaaaaaaaaaaaaaaaaaaal");
                return RedirectToAction("Index","Conge");
            }
            else {
                Debug.WriteLine("hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
               return RedirectToAction("Login");
            }
                
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
        }
    }
}