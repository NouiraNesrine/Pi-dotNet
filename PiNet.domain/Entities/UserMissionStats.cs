namespace PiNet.domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.usermissionstats")]
    public partial class UserMissionStats
    {
        [Key]
        public int refrence { get; set; }

        public double applicationAmount { get; set; }

        public double participantionAmount { get; set; }

        public int? user_idUser { get; set; }

        public virtual User user { get; set; }
    }
}
