using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EF_CORE.Data;
using System.Threading.Tasks;

namespace EF_CORE.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=UserDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>() // отношение один-к-одному
            .HasOne(s => s.UserProfile)
            .WithOne(ps => ps.Student)
            .HasForeignKey<UserProfile>(ps => ps.UserId);

            modelBuilder.Entity<Role>() // отношение один-ко-многим
            .HasMany(g => g.Students)
            .WithOne(s => s.Role)
            .HasForeignKey(s => s.RoleId);
        }
    }
}
