namespace data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using PiNet.domain.Entities;

    public partial class PiContext : DbContext
    {
        public PiContext()
            : base("name=PiContext")
        {
            this.Configuration.ValidateOnSaveEnabled = false;
        }
       /* static PiContext()
        {
            DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
        }
        */
        public virtual DbSet<AccommodationExpenses> accommodationexpenses { get; set; }
        public virtual DbSet<activity> activity { get; set; }
        public virtual DbSet<conge> conge { get; set; }
        public virtual DbSet<contrat> contrat { get; set; }
        public virtual DbSet<decision> decision { get; set; }
        public virtual DbSet<decisionreference> decisionreference { get; set; }
        public virtual DbSet<evaluationsheet> evaluationsheet { get; set; }
        public virtual DbSet<ExpenseNote> expensenote { get; set; }
        public virtual DbSet<formation> formation { get; set; }
        public virtual DbSet<jobdescription> jobdescription { get; set; }
        public virtual DbSet<Mission> mission { get; set; }
        public virtual DbSet<MissionExpenses> missionexpenses { get; set; }
        public virtual DbSet<objectif> objectif { get; set; }
        public virtual DbSet<OtherExpenses> otherexpenses { get; set; }
        public virtual DbSet<RestaurationExpenses> restaurationexpenses { get; set; }
        public virtual DbSet<Skills> skills { get; set; }
        public virtual DbSet<timesheet> timesheet { get; set; }
        public virtual DbSet<TransportExpenses> transportexpenses { get; set; }
        public virtual DbSet<User> user { get; set; }
        public virtual DbSet<UserMissionStats> usermissionstats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          /*  modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);*/

            modelBuilder.Entity<AccommodationExpenses>()
                .Property(e => e.accommodationBill)
                .IsUnicode(false);

            modelBuilder.Entity<AccommodationExpenses>()
                .Property(e => e.acctype)
                .IsUnicode(false);

            modelBuilder.Entity<AccommodationExpenses>()
                .HasMany(e => e.expenseNote)
                .WithMany(e => e.accommodationexpenses)
                .Map(m => m.ToTable("expensenote_accommodationexpenses").MapLeftKey("accommodationExp_id").MapRightKey("ExpenseNote_refrence"));

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

            modelBuilder.Entity<decisionreference>()
                .HasMany(e => e.decision)
                .WithOptional(e => e.decisionreference)
                .HasForeignKey(e => e.decisionRef_idDecRef);

            modelBuilder.Entity<evaluationsheet>()
                .HasMany(e => e.decision)
                .WithOptional(e => e.evaluationsheet)
                .HasForeignKey(e => e.evaluation_evalId);

            modelBuilder.Entity<ExpenseNote>()
                .HasMany(e => e.otherexpenses)
                .WithMany(e => e.expensenote)
                .Map(m => m.ToTable("expensenote_otherexpenses").MapLeftKey("ExpenseNote_refrence").MapRightKey("otherExp_id"));

            modelBuilder.Entity<ExpenseNote>()
                .HasMany(e => e.transportexpenses)
                .WithMany(e => e.expensenote)
                .Map(m => m.ToTable("expensenote_transportexpenses").MapLeftKey("ExpenseNote_refrence").MapRightKey("tansportExp_id"));

            modelBuilder.Entity<ExpenseNote>()
                .HasMany(e => e.missionexpenses)
                .WithMany(e => e.expensenote)
                .Map(m => m.ToTable("missionexpenses_expensenote").MapLeftKey("expenseNotes_refrence").MapRightKey("MissionExpenses_refrence"));

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

            modelBuilder.Entity<Mission>()
                .Property(e => e.client)
                .IsUnicode(false);

            modelBuilder.Entity<Mission>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Mission>()
                .Property(e => e.place_intervention)
                .IsUnicode(false);

            modelBuilder.Entity<Mission>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<Mission>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Mission>()
                .HasMany(e => e.expensenote)
                .WithOptional(e => e.mission)
                .HasForeignKey(e => e.mission_refrence);

            modelBuilder.Entity<Mission>()
                .HasMany(e => e.missionexpenses)
                .WithOptional(e => e.mission)
                .HasForeignKey(e => e.mission_refrence);

            modelBuilder.Entity<Mission>()
                .HasMany(e => e.participants)
                .WithMany(e => e.mission2)
                .Map(m => m.ToTable("mission_user", "pidev").MapLeftKey("Mission_refrence").MapRightKey("participants_idUser"));

            modelBuilder.Entity<objectif>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<objectif>()
                .HasMany(e => e.evaluationsheet)
                .WithOptional(e => e.objectif)
                .HasForeignKey(e => e.objectif_idObjectif);

            modelBuilder.Entity<OtherExpenses>()
                .Property(e => e.bill)
                .IsUnicode(false);

            modelBuilder.Entity<OtherExpenses>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<OtherExpenses>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<RestaurationExpenses>()
                .Property(e => e.restaurationBill)
                .IsUnicode(false);

            modelBuilder.Entity<RestaurationExpenses>()
                .HasMany(e => e.expensenote)
                .WithMany(e => e.restaurationexpenses)
                .Map(m => m.ToTable("expensenote_restaurationexpenses").MapLeftKey("restaurationExp_id").MapRightKey("ExpenseNote_refrence"));

            modelBuilder.Entity<Skills>()
                .Property(e => e.categorie)
                .IsUnicode(false);

            modelBuilder.Entity<Skills>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Skills>()
                .Property(e => e.niveau)
                .IsUnicode(false);

            modelBuilder.Entity<Skills>()
                .Property(e => e.nomCompetence)
                .IsUnicode(false);

            modelBuilder.Entity<Skills>()
                .Property(e => e.skillsRef)
                .IsUnicode(false);

            modelBuilder.Entity<Skills>()
                .HasMany(e => e.formation)
                .WithOptional(e => e.skills)
                .HasForeignKey(e => e.skillsF_idSkills);

            modelBuilder.Entity<Skills>()
                .HasMany(e => e.jobdescription)
                .WithMany(e => e.skills)
                .Map(m => m.ToTable("jobdescription_skills", "pidev").MapLeftKey("JDSkilss_idSkills").MapRightKey("ListJD_idJob"));

            modelBuilder.Entity<Skills>()
                .HasMany(e => e.mission)
                .WithMany(e => e.skillsRequired)
                .Map(m => m.ToTable("mission_skills", "pidev").MapLeftKey("skillsRequired_idSkills").MapRightKey("Mission_refrence"));

            modelBuilder.Entity<Skills>()
                .HasMany(e => e.user)
                .WithMany(e => e.skills)
                .Map(m => m.ToTable("user_skills").MapLeftKey("Userskills_idSkills").MapRightKey("listUserinSkills_idUser"));

            modelBuilder.Entity<timesheet>()
                .Property(e => e.isActive)
                .IsUnicode(false);

            modelBuilder.Entity<timesheet>()
                .HasMany(e => e.activity)
                .WithOptional(e => e.timesheet)
                .HasForeignKey(e => e.timesheet_id);

            modelBuilder.Entity<TransportExpenses>()
                .Property(e => e.boardingTicket)
                .IsUnicode(false);

            modelBuilder.Entity<TransportExpenses>()
                .Property(e => e.trspType)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Firstname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Lastname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.conge)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_idUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.contrat)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_idUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.evaluationsheet)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_idUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.expensenote)
                .WithOptional(e => e.employee)
                .HasForeignKey(e => e.employee_idUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.expensenote1)
                .WithOptional(e => e.officer)
                .HasForeignKey(e => e.officer_idUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.mission)
                .WithOptional(e => e.suprvisedBy)
                .HasForeignKey(e => e.suprvisedBy_idUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.mission1)
                .WithOptional(e => e.postedBy)
                .HasForeignKey(e => e.postedBy_idUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.timesheet)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_idUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.usermissionstats)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_idUser);

            modelBuilder.Entity<User>()
                .HasMany(e => e.formation)
                .WithMany(e => e.user)
                .Map(m => m.ToTable("formation_user", "pidev").MapLeftKey("UsersParticipants_idUser").MapRightKey("formations_idFormation"));
        }
    }
}
