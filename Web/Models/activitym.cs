using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class activitym
    {

        public int id { get; set; }

        public int NombreHeuresEstimer { get; set; }

        public int NombreHeuresTravailler { get; set; }

        public DateTime? dateFin { get; set; }

        public DateTime? datedebut { get; set; }

        public string description { get; set; }

        public string nom { get; set; }

        public string statut { get; set; }

        public int? projet_id { get; set; }

        public int? user_idUser { get; set; }

      public  int nbheureEstimer()
        {
            int somme = 0;
              var activities = new List<activity>();

            
            foreach (activity  ac in activities)
            {
             
                somme = +ac.NombreHeuresEstimer;


            }

            return somme;
        }

        public float pourcentagetravailler()
        { return  (NombreHeuresTravailler * 100) / NombreHeuresEstimer; }

    }
}