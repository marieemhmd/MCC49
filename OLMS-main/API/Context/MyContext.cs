using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext() { }
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<NationalHoliday> NationalHolidays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(a => a.Account)
                .WithOne(e => e.Employee)
                .HasForeignKey<Account>(b => b.NIK)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Position)
                .WithMany(p => p.Employees)
                .HasForeignKey(fk => fk.PositionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Position>()
                .HasOne(d => d.Department)
                .WithMany(p => p.Positions)
                .HasForeignKey(fk => fk.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Manager)
                .WithMany()
                .HasForeignKey(m => m.NIK_Manager);

            modelBuilder.Entity<Request>()
                .HasOne(r => r.Employee)
                .WithMany(req => req.Requests)
                .HasForeignKey(fk => fk.NIK_Employee)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AccountRole>()
                .HasKey(ar => new { ar.NIK});

            modelBuilder.Entity<AccountRole>()
                .HasOne(a => a.Account)
                .WithMany(ar => ar.AccountRoles)
                .HasForeignKey(a => a.NIK);

            modelBuilder.Entity<AccountRole>()
                .HasOne(r => r.Role)
                .WithMany(ar => ar.AccountRoles)
                .HasForeignKey(r => r.RoleID);

            modelBuilder.Entity<NationalHoliday>()
                .HasOne(r => r.Request)
                .WithMany(nh => nh.Holidays)
                .HasForeignKey(fk => fk.RequestId);
                

            base.OnModelCreating(modelBuilder);
        }
    }
}
