namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.timesheet")]
    public partial class timesheet
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ClockIn { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LastClockOut { get; set; }

        public int NombreHeureTravailler { get; set; }

        public int NombreJoursTravaillerParmois { get; set; }

        [StringLength(255)]
        public string isActive { get; set; }

        public int? user_idUser { get; set; }
    }
}
