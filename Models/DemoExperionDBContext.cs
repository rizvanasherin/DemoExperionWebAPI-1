using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoExperionWebAPI_1.Models
{
    public partial class DemoExperionDBContext : DbContext
    {
        public DemoExperionDBContext()
        {
        }

        public DemoExperionDBContext(DbContextOptions<DemoExperionDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source= RISVANASHERIN\\SQLEXPRESS; Initial Catalog= DemoExperionDB; Integrated security=True");
            }
        }
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");

                entity.Property(e => e.Contact)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateofJoining).HasColumnType("date");

                entity.Property(e => e.Department)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Designation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .HasColumnName("Employee_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
