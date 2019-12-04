using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PiNet.domain.Entities;

namespace PiNet.web.Models
{
    public class UserModel
    {
        public int idUser { get; set; }
        
        public string Firstname { get; set; }
        
        public string Lastname { get; set; }
        
        public string email { get; set; }
        
        public bool? activ { get; set; }
        
        public string password { get; set; }
        
        public string role { get; set; }

        public virtual ICollection<SkillModel> skills { get; set; }
        // web service POST postuler pour une mission + skills required= user skills
    }
}