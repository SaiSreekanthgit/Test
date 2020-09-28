using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Test.Models
{
    public partial class TestsContext : DbContext
    {
        public TestsContext()
        {
        }

        public TestsContext(DbContextOptions<TestsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Municipality> Municipality { get; set; }
        public virtual DbSet<MunicipalityTax> MunicipalityTax { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
            //if (!optionsBuilder.IsConfigured)
            //{
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=HMECL001973;Database=Tests;Trusted_Connection=True;");
            //}
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Municipality>(entity =>
            {
                entity.Property(e => e.MunicipalityId).HasColumnName("MunicipalityID");

                entity.Property(e => e.MunicipalityName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MunicipalityTax>(entity =>
            {
                entity.Property(e => e.MunicipalityTaxId).HasColumnName("MunicipalityTaxID");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.MunicipalityId).HasColumnName("MunicipalityID");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.HasOne(d => d.Municipality)
                    .WithMany(p => p.MunicipalityTax)
                    .HasForeignKey(d => d.MunicipalityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MunicipalityTax_Municipality");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
