using Data;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Web.Models;


namespace Web.Controllers
{
    public class ProjectController : Controller
    {
        serviceprojet sc = new projetService();
        activityInterface ac = new ActivityService();
        activitym acc = new activitym();
        Context d = new Context();


        public ActionResult Index(string searchString)
        {


            List<projetm> lc = new List<projetm>();
            if (searchString == null)
            {
                List<projetm> lo = new List<projetm>();
                foreach (var cm in sc.GetAll())
                {
                    projetm c = new projetm();

                    c.nom = cm.nom;
                    c.id = cm.id;
                  //  c.description = cm. ;
                    c.description = cm.description;
                    c.NombreHeuresEstimer = cm.NombreHeuresEstimer;
                    c.NombreHeuresTravailler = cm.NombreHeuresTravailler;
                    c.NombreHeuresEnRetard = cm.NombreHeuresEnRetard;
                    c.mailClient = cm.mailClient;
                    lc.Add(c);
                    ViewBag.nbprojet = lc.Count;


                    ViewBag.nbhTr = lc.Count(x => x.NombreHeuresTravailler>1);
                    ViewBag.nbhEst = lc.Count(x => x.NombreHeuresEstimer > 1);
                    ViewBag.nbpretard = lc.Count(x => x.NombreHeuresEnRetard == 0);
                    //  ViewBag.nbpr = lc.Count(x =>+x.NombreHeuresEstimer);


                    if (ViewBag.nbhTr == ViewBag.nbhEst &&ViewBag.nbpretard == 0)
                    {
                        
                      
                            ViewBag.nbprojetComplet =+1;
                        
                    }
                   
                 //   ViewBag.nbProjetTerminé = lc.Count(ViewBag.nbpr && ViewBag.nbpretard);

                    //ord.NombreHeuresEstimer = ordd1.Sum(x => +x.NombreHeuresEstimer);

                }
                return View(lc);
            }
            else
            {
                foreach (var item in sc.GetAll())
                {
                    if (item.nom.Contains(searchString))
                    {
                        projetm pvm = new projetm();
                        pvm.id = item.id;
                        pvm.description = item.description;
                        pvm.nom = item.nom;
                        pvm.mailClient = item.mailClient;
                    //    pvm.prix = item.prix;

                        lc.Add(pvm);

                        return View(lc);
                    }

                }
            }


            return View(lc);




        }
        
        // private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Project
       /*  public ActionResult Index()
         {

             var projets = new List<projetm>();
             foreach (projet pdomain in sc.GetMany())
             {
                 projets.Add(new projetm()
                 {
                     id = pdomain.id,

                     nom = pdomain.nom,
                     description = pdomain.description,
                     mailClient = pdomain.mailClient,

                     // Image = pdomain.Image,
                     NombreHeuresEstimer = pdomain.NombreHeuresEstimer,
                     //NombreHeuresEstimer = pdomain.NombreHeuresEstimer=acc.nbheureEstimer,

                     NombreHeuresTravailler = pdomain.NombreHeuresTravailler,
                     NombreHeuresEnRetard = pdomain.NombreHeuresEnRetard

                 });
                //    ViewBag.nbAct = sc.GetMany(x => x.id == pdomain.id).get );
                //    ViewBag.nbAct = ordd1.Count;
              


            //    ViewBag.ClientFidele = query.Max();
                ViewBag.nbprojet = projets.Count;
             }


             return View(projets);

         }

       

       */

        /*

                public ActionResult showOrderByProject()
                {

                    var projets = new List<projetm>();
                    foreach (projet pdomain in sc.GetMany())
                    {
                        ViewBag.total4 = projets.OrderByDescending(x => +x.NombreHeuresTravailler);

                        projets = ViewBag.total4;
                        projets.Add(new projetm()
                        {
                            id = pdomain.id,
                            nom = pdomain.nom,
                            description = pdomain.description,
                            mailClient = pdomain.mailClient,

                            // Image = pdomain.Image,
                            NombreHeuresEstimer = pdomain.NombreHeuresEstimer,
                            //NombreHeuresEstimer = pdomain.NombreHeuresEstimer=acc.nbheureEstimer,

                            NombreHeuresTravailler = pdomain.NombreHeuresTravailler,
                            NombreHeuresEnRetard = pdomain.NombreHeuresEnRetard
                        });
                        // ViewBag.NombreHeuresEstimer = ac.GetMany(x => x.projet_id == pdomain.id).Sum(x => x.NombreHeuresEstimer );

                    }


                    return View(projets);

                }
                */

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            //ViewBag.total2 = ordd1.Sum(x => +x.NombreHeuresTravailler);

            var c = sc.GetById(id);

            projetm d = new projetm();

            d.id = c.id;
            d.nom = c.nom;
            d.description = c.description;
            d.mailClient = c.mailClient;
            d.NombreHeuresTravailler = c.NombreHeuresTravailler;
            d.NombreHeuresEstimer = c.NombreHeuresEstimer;
            d.NombreHeuresEnRetard = c.NombreHeuresEnRetard;






            return View(d);
        }

        public ActionResult getActivties(int id)
        {

            // IndexbilId(int idp)
            /*
             List<activity> ordd1 = ac.GetMany(x => x.id == id).ToList();
             ActivityManagerController getlist = new ActivityManagerController();
             getlist.IndexbilId(id);

             */

            //  return getlist.IndexbilId(id); 


            List<activity> ords = ac.GetMany(x => x.projet_id == id).ToList();
            return View(ords);
        }
        public ActionResult ConfirmOrder(int id)
        {
            List<projet> ordd1 = sc.GetMany(x => x.id == id).ToList();

            foreach (var itemmm in ordd1)
            {
                if( (itemmm.NombreHeuresEnRetard<0)  && ((itemmm.NombreHeuresEstimer == itemmm.NombreHeuresTravailler)) )
                {

                    MailMessage mail = new MailMessage();

                    String nom = "";
                    foreach (var item in ordd1)
                    {
                        nom = item.mailClient;
                    }
                    mail.From = new MailAddress(nom);
                    mail.To.Add(nom);
                    mail.Subject = "project completed with succes";
                    string ordersdettail = "your order that contains this Project ";

                    foreach (var item in ordd1)
                    {
                        ordersdettail += " project name : " + item.nom + "| description = " + item.description;
                    }

                    mail.Body = ordersdettail;
                    // MailMessage.Priority = MailPriority.Normal;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    NetworkCredential nc = new System.Net.NetworkCredential("aadvteam@gmail.com", "123advteamm");

                    smtp.EnableSsl = true;
                    smtp.Credentials = nc;
                    smtp.Send(mail);



                   
                }

                if ((itemmm.NombreHeuresEnRetard > 0 )&& ((itemmm.NombreHeuresEstimer < itemmm.NombreHeuresTravailler)))
                {
                    MailMessage mail = new MailMessage();

                    String nom = "";
                    foreach (var item in ordd1)
                    {
                        nom = item.mailClient;
                    }
                    mail.From = new MailAddress(nom);
                    mail.To.Add(nom);
                    mail.Subject = "Project miss delayed Notice";
                    string ordersdettail = "We are sorry to  inform that you we our late for our work schedule  ";

                    foreach (var item in ordd1)
                    {
                        ordersdettail += " project name : " + item.nom + "| description = " + item.description;
                    }

                    mail.Body = ordersdettail;
                    // MailMessage.Priority = MailPriority.Normal;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    NetworkCredential nc = new System.Net.NetworkCredential("aadvteam@gmail.com", "123advteamm");

                    smtp.EnableSsl = true;
                    smtp.Credentials = nc;
                    smtp.Send(mail);



                  //  return RedirectToAction("Index", "Home");

                }
                if ((itemmm.NombreHeuresEnRetard <= 0) && ((itemmm.NombreHeuresEstimer > itemmm.NombreHeuresTravailler)))
                {

                    MailMessage mail = new MailMessage();

                    String nom = "";
                    foreach (var item in ordd1)
                    {
                        nom = item.mailClient;
                    }
                    mail.From = new MailAddress(nom);
                    mail.To.Add(nom);
                    mail.Subject = "Project Still going on";
                    string ordersdettail = "Project Still in progress ";

                    foreach (var item in ordd1)
                    {
                        ordersdettail += " project name : " + item.nom + "| description = " + item.description;
                    }

                    mail.Body = ordersdettail;
                    // MailMessage.Priority = MailPriority.Normal;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    NetworkCredential nc = new System.Net.NetworkCredential("aadvteam@gmail.com", "123advteamm");

                    smtp.EnableSsl = true;
                    smtp.Credentials = nc;
                    smtp.Send(mail);


                }


            }

            /*
                        MailMessage mail = new MailMessage();

                        String nom="";
                        foreach (var item in ordd1)
                        {
                            nom =  item.mailClient ;
                        }
                        mail.From = new MailAddress(nom);
                        mail.To.Add("takwa.souai@esprit.tn");
                        mail.Subject = "project completed with succes";
                        string ordersdettail = "your order that contains this Project ";

                        foreach (var item in ordd1)
                        {
                            ordersdettail += " project name : " + item.nom + "| description = " + item.description  ;
                        }

                        mail.Body = ordersdettail ;
                       // MailMessage.Priority = MailPriority.Normal;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        NetworkCredential nc = new System.Net.NetworkCredential("aadvteam@gmail.com", "123advteamm");

                        smtp.EnableSsl = true;
                        smtp.Credentials = nc;
                        smtp.Send(mail);



                        return RedirectToAction("Index", "Home");
                        */

            return RedirectToAction("Index", "Home");


        }
        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }
     
    

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(projetm collection)
        {

            projet c = new projet();


            c.id = collection.id;
            c.nom = collection.nom;
            c.description = collection.description;
            c.mailClient = collection.mailClient;
            

             

            sc.Add(c);
            sc.Commit();
            //   return View();
            return RedirectToAction("Index");
        }

        


        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            //var categories = es.GetMany();
          //  ViewBag.categorieFK = new SelectList(categories, "nomC", "nomC");
       //     return View(sc.GetById(id));
            return View();
        }
      
        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, projetm ord)
        {

            List<activity> ordd1 = ac.GetMany(x => x.projet_id == id).ToList();

            ViewBag.total = ordd1.Sum(x => +x.NombreHeuresEstimer);
            //ord.NombreHeuresEstimer = ordd1.Sum(x => +x.NombreHeuresEstimer);
            // ViewBag.ordd = ordd1;
            ViewBag.total2 = ordd1.Sum(x => +x.NombreHeuresTravailler);

            try
            {

                projet order = sc.GetById(id);
                order.nom = ord.nom;
                order.description = ord.description;
                order.mailClient = ord.mailClient;
                order.NombreHeuresEstimer = ViewBag.total;
                order.NombreHeuresTravailler = ViewBag.total2;


                if ((ViewBag.total2 - ViewBag.total) > 0)
                {
                    order.NombreHeuresEnRetard = ViewBag.total2 - ViewBag.total;
                }
                else
                { order.NombreHeuresEnRetard = 0; }
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
        public ActionResult Avancement(int id)
        {

           // int pourcentageRestante;

            //   NewOrder ord = spno.GetById(id);
            projet ord = sc.GetById(id);

            List<activity> ordd1 = ac.GetMany(x => x.projet_id == id).ToList();
            foreach (var a in ordd1)
            {
                //   a.product = spp.GetById(a.Productid);
            }
            ViewBag.total = ordd1.Sum(x => +x.NombreHeuresEstimer);
            ord.NombreHeuresEstimer = ordd1.Sum(x => +x.NombreHeuresEstimer);
            ViewBag.ordd = ordd1;

         
            // nb tr

            ViewBag.total2 = ordd1.Sum(x => +x.NombreHeuresTravailler);
            ord.NombreHeuresTravailler = ordd1.Sum(x => +x.NombreHeuresTravailler);
            ViewBag.ordd = ordd1;

            // nb retard 
            /* ViewBag.total3 = ordd1.Sum(y=>ordd1.Sum(x => +x.NombreHeuresTravailler) - ordd1.Sum(x => +x.NombreHeuresTravailler));
             ord.NombreHeuresEnRetard = ordd1.Sum(y => ordd1.Sum(x => +x.NombreHeuresTravailler) - ordd1.Sum(x => +x.NombreHeuresTravailler));
             ViewBag.ordd = ordd1;
             */




            if ((ViewBag.total2 - ViewBag.total) > 0)
            {
                ord.NombreHeuresEnRetard = ViewBag.total2 - ViewBag.total;

            }
            else
            { ord.NombreHeuresEnRetard = 0; }

            ViewBag.ordd = ordd1;

            // ord.NombreHeuresEnRetard = ViewBag.total2 - ViewBag.total;

            //  ord.NombreHeuresEstimer = sc.Update(ord.NombreHeuresEstimer= ViewBag.total);
            // pourcentage projets



            //  pourcentageRestante = ord.NombreHeuresEstimer - (ord.NombreHeuresTravailler);

            // affectation 


            ViewBag.nbAct = ordd1.Count;
            return View(ord);
        }

        public ActionResult PrintAllEmployee()
        {
            var report = new Rotativa.ActionAsPdf("Index");
            return report;
        }
        public ActionResult EmployeeImage()
        {
            var report = new Rotativa.ActionAsImage("Index");
            return report;
        }
        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            projet c = sc.GetById(id);

            sc.Delete(c);
            sc.Commit();
            return RedirectToAction("Index");
        }

        // POST: Project/Delete/5
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

            //
            // GET: /Project/avancement


     


            /*    int nbnbheureEstimer()
              {
                  int somme = 4;
                  var activities = new List<activitym>();


                  foreach (activitym ac in activities)
                  {

                      somme = +ac.NombreHeuresEstimer;


                  }

                  return somme;
              }
              */






        }
    }
}
