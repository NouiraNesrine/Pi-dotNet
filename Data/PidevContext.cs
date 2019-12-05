namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PidevContext : DbContext
    {
        public PidevContext()
            : base("name=PidevContext")
        {
        }

        public virtual DbSet<formation> formation { get; set; }
        public virtual DbSet<quiz> quiz { get; set; }
        public virtual DbSet<reponse> reponse { get; set; }
        public virtual DbSet<user> user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<formation>()
                .Property(e => e.Formateur)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.NomF)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.categorie)
                .IsUnicode(false);

           

            modelBuilder.Entity<reponse>()
                .Property(e => e.r1)
                .IsUnicode(false);

            modelBuilder.Entity<reponse>()
                .Property(e => e.r2)
                .IsUnicode(false);

            modelBuilder.Entity<reponse>()
                .Property(e => e.r3)
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
    }
}
