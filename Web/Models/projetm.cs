using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class projetm
    {
      //  int nombreHeuresEstimer = 7;
        public int id { get; set; }


        public int NombreHeuresEnRetard { get; set; }

        public int NombreHeuresEstimer  { get; set; }
        //   public int NombreHeuresEstimer = nbnbheureEstimer();
       // public int NombreHeuresEstimer = 7;

        public int NombreHeuresTravailler { get; set; }
       

        public string description { get; set; }

        public string mailClient { get; set; }
        [Required]

        public string nom { get; set; }
        //   int nb = ac.nbheureEstimer;
       //public float pourcentageRestante;

        public float pourcentageRestante()
        { return (((NombreHeuresEstimer - NombreHeuresTravailler)*100)/NombreHeuresEstimer) ; }
    }
}