namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
   // [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class PidevContext : DbContext
    {
        public PidevContext()
            : base("PidevContext")
        {
        }

        public virtual DbSet<decision> decision { get; set; }
        public virtual DbSet<decisionreference> decisionreference { get; set; }
        public virtual DbSet<evaluationsheet> evaluationsheet { get; set; }
        public virtual DbSet<rate> rate { get; set; }
        public virtual DbSet<user> user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<decision>()
                .Property(e => e.typeDec)
                .IsUnicode(false);

            modelBuilder.Entity<decision>()
                .HasMany(e => e.evaluationsheet)
                .WithOptional(e => e.decision)
                .HasForeignKey(e => e.decision_idDecision);

            modelBuilder.Entity<decisionreference>()
                .HasMany(e => e.decision)
                .WithOptional(e => e.decisionreference)
                .HasForeignKey(e => e.decisionRef_idDecRef);

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

            modelBuilder.Entity<user>()
                .HasMany(e => e.evaluationsheet)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_idUser);

            modelBuilder.Entity<user>()
                .HasMany(e => e.rate)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_idUser);

         /* modelBuilder.Entity<rate>().Ignore(e => e.user);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<evaluationsheet>().Ignore(e => e.user);
            base.OnModelCreating(modelBuilder);*/
        }
    }
}
