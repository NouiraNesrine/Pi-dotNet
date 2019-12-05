namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PidevContext : DbContext
    {
        public PidevContext()
            : base("PidevContext")
        {
        }

        public virtual DbSet<commentaire> commentaires { get; set; }
        public virtual DbSet<conge> conges { get; set; }
        public virtual DbSet<statu> status { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<commentaire>()
                .Property(e => e.descriptionCom)
                .IsUnicode(false);

            modelBuilder.Entity<conge>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<statu>()
                .Property(e => e.description)
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

            modelBuilder.Entity<user>()
                .Property(e => e.value)
                .IsUnicode(false);
        }
    }
}
