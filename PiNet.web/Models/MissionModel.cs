using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PiNet.domain.Entities;

namespace PiNet.web.Models
{
    public class MissionModel
    {
        

       public int refrence { get; set; }
        public string date { get; set; }

        public string date_start { get; set; }
        //date error
        public string date_finish { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public string client { get; set; }

        public string place_intervention { get; set; }
        
        public double estimated_budget { get; set; }

        public bool? isRembursable { get; set; }

        public string state { get; set; }

        public bool? isPosterManager { get; set; }

        public bool? isAnnulationRisque { get; set; }
        
        public UserModel postedBy { get; set; }

        public UserModel suprvisedBy { get; set; }

        public virtual ICollection<UserModel> participants { get; set; }

        public virtual ICollection<SkillModel> skillsRequired { get; set; }
        

        }
}