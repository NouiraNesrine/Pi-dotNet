using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiNet.domain.Entities;
using data;
using PiNet.service;
namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
           /* PiContext ctx = new PiContext();
            TrspExpService t = new TrspExpService();
               RestaurationExpenses r = new RestaurationExpenses() { costs=350 , restaurationBill="bill.jpg" };
               ctx.restaurationexpenses.Add(r);
               ctx.SaveChanges();
           
               TransportExpenses tt = new TransportExpenses() { trspType= "WaterLine" , costs=1300 , boardingTicket="ticket.jpg" };
               ctx.transportexpenses.Add(tt);
               ctx.SaveChanges();


            TransportExpenses tp = t.GetById(1);
            tp.costs = 500;
            t.Update(tp);
            
            t.Commit();*/
            MissionService m = new MissionService();
            Console.WriteLine(m.GetById(1).title);
            foreach (var item in m.GetAll())
                {
                Console.WriteLine(item.date);
            }
            

            


            Console.ReadKey();

        }
    }
}
