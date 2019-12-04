using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PiNet.domain.Entities;

namespace PiNet.web.Models
{
    public class SkillModel
    {
        public int idSkills { get; set; }

        public string categorie { get; set; }

        public string description { get; set; }

        public string niveau { get; set; }

        public string nomCompetence { get; set; }

        public string skillsRef { get; set; }

        public virtual ICollection<formation> listFormations { get; set; }

        public virtual ICollection<jobdescription> listJD { get; set; }
        
        public virtual ICollection<UserModel> listUserinSkills { get; set; }
    }
}