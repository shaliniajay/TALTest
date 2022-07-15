using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestTAL.Api.DA
{
    public partial class TALContext : DbContext
    {
        public TALContext()
        {
        }

        public TALContext(DbContextOptions<TALContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Occupation> Occupations { get; set; } = null!;
        public virtual DbSet<OccupationFactor> OccupationFactors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectModels;Database=TAL;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Occupation>(entity =>
            {
                entity.ToTable("Occupation");

                entity.Property(e => e.OccupationId).HasColumnName("OccupationID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OccupationFactorId).HasColumnName("OccupationFactorID");

                entity.HasOne(d => d.OccupationFactor)
                    .WithMany(p => p.Occupations)
                    .HasForeignKey(d => d.OccupationFactorId)
                    .HasConstraintName("FK__Occupatio__Occup__267ABA7A");
            });

            modelBuilder.Entity<OccupationFactor>(entity =>
            {
                entity.ToTable("OccupationFactor");

                entity.Property(e => e.OccupationFactorId).HasColumnName("OccupationFactorID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
