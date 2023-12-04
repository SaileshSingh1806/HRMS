using HRMS.Authentication;
using HRMS.DTO;
using HRMS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace HRMS.Data
{
    public partial class HRMSDbContext : IdentityDbContext<ApplicationUser>
    {
        public HRMSDbContext(DbContextOptions<HRMSDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;

        public DbSet<Leave> Leave { get; set; }
        
        public DbSet<LeaveRequest> LeaveRequest { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<LeaveRequest>()
           .HasOne(_ => _.Leave)
            .WithMany(a => a.LeaveRequests)
           .HasForeignKey(p => p.LeaveId);

            //modelBuilder.Entity<Employee>(entity =>
            //{
            //    entity.HasKey(e => e.Id);

            //    entity.ToTable("Employee");

            //    entity.Property(e => e.Id).HasColumnName("Id");

            //    entity.Property(e => e.ActiveForm)
            //        .HasColumnType("date")
            //        .HasColumnName("Active Form");

            //    entity.Property(e => e.Address)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.AssignedManager)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasColumnName("Assigned Manager");

            //    entity.Property(e => e.BirthDate).HasColumnType("date");

            //    entity.Property(e => e.BloodGroup)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasColumnName("BloodGroup");

            //    entity.Property(e => e.City)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Designation)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Email)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasColumnName("Name");

            //    entity.Property(e => e.Gender)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.JoiningDate)
            //        .HasColumnType("date")
            //        .HasColumnName("Joining Date");

            //    entity.Property(e => e.MobileNumber)
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .HasColumnName("Mobile Number");

            //    entity.Property(e => e.Organization)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Role)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Status)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});
            base.OnModelCreating(modelBuilder);
        }

     

    }
}
