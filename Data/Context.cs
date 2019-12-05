namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<accommodationexpens> accommodationexpenses { get; set; }
        public virtual DbSet<activity> activities { get; set; }
        public virtual DbSet<conge> conges { get; set; }
        public virtual DbSet<contrat> contrats { get; set; }
        public virtual DbSet<decision> decisions { get; set; }
        public virtual DbSet<decisionreference> decisionreferences { get; set; }
        public virtual DbSet<evaluationsheet> evaluationsheets { get; set; }
        public virtual DbSet<expensenote> expensenotes { get; set; }
        public virtual DbSet<formation> formations { get; set; }
        public virtual DbSet<formation_user> formation_user { get; set; }
        public virtual DbSet<jobdescription> jobdescriptions { get; set; }
        public virtual DbSet<jobdescription_skills> jobdescription_skills { get; set; }
        public virtual DbSet<mission> missions { get; set; }
        public virtual DbSet<missionexpens> missionexpenses { get; set; }
        public virtual DbSet<objectif> objectifs { get; set; }
        public virtual DbSet<projet> projets { get; set; }
        public virtual DbSet<skill> skills { get; set; }
        public virtual DbSet<timesheet> timesheets { get; set; }
        public virtual DbSet<transportexpens> transportexpenses { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<expensenote_accommodationexpenses> expensenote_accommodationexpenses { get; set; }
        public virtual DbSet<expensenote_transportexpenses> expensenote_transportexpenses { get; set; }
        public virtual DbSet<mission_user> mission_user { get; set; }
        public virtual DbSet<missionexpenses_expensenote> missionexpenses_expensenote { get; set; }
        public virtual DbSet<user_skills> user_skills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<accommodationexpens>()
                .Property(e => e.accommodationBill)
                .IsUnicode(false);

            modelBuilder.Entity<accommodationexpens>()
                .Property(e => e.acctype)
                .IsUnicode(false);

            modelBuilder.Entity<activity>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<activity>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<activity>()
                .Property(e => e.statut)
                .IsUnicode(false);

            modelBuilder.Entity<conge>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<contrat>()
                .Property(e => e.typeContrat)
                .IsUnicode(false);

            modelBuilder.Entity<decision>()
                .Property(e => e.typeDec)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.Formateur)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.NomF)
                .IsUnicode(false);

            modelBuilder.Entity<jobdescription>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<jobdescription>()
                .Property(e => e.nom_competence)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.skillsRequired)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.subject)
                .IsUnicode(false);

            modelBuilder.Entity<objectif>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<projet>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<projet>()
                .Property(e => e.mailClient)
                .IsUnicode(false);

            modelBuilder.Entity<projet>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<skill>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<skill>()
                .Property(e => e.nomCompetence)
                .IsUnicode(false);

            modelBuilder.Entity<timesheet>()
                .Property(e => e.isActive)
                .IsUnicode(false);

            modelBuilder.Entity<transportexpens>()
                .Property(e => e.boardingTicket)
                .IsUnicode(false);

            modelBuilder.Entity<transportexpens>()
                .Property(e => e.trspType)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Firstname)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Lastname)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.role)
                .IsUnicode(false);
        }

    //    object placeHolderVariable;
      //  public System.Data.Entity.DbSet<Web.Models.activitym> activityms { get; set; }
    }
}
