using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PiNet.domain.Entities;

namespace PiNet.web.Models
{
    public class ExpenseNoteModel
    {
        public int refrence { get; set; }

        public DateTime? date { get; set; }

        public bool? isApproved { get; set; }

        public double totalCost { get; set; }

        public double totalRecovered { get; set; }

        public int? employee_idUser { get; set; }

        public int? mission_refrence { get; set; }

        public int? officer_idUser { get; set; }

        public virtual MissionModel mission { get; set; }

        public virtual UserModel user { get; set; }

       

        public virtual ICollection<AccommodationExpenses> accommodationexpenses { get; set; }

        public virtual ICollection<OtherExpenses> otherexpenses { get; set; }

        public virtual ICollection<RestaurationExpenses> restaurationexpenses { get; set; }

        public virtual ICollection<TransportExpenses> transportexpenses { get; set; }

        public virtual ICollection<MissionExpenses> missionexpenses { get; set; }
    }
}