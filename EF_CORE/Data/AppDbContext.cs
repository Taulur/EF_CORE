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
        public DbSet<UserInterestGroup> UserInterestGroups { get; set; }
        public DbSet<InterestGroup> InterestGroups { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=UserDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>() 
            .HasOne(s => s.UserProfile)
            .WithOne(ps => ps.Student)
            .HasForeignKey<UserProfile>(ps => ps.UserId);

            modelBuilder.Entity<Role>() 
            .HasMany(g => g.Students)
            .WithOne(s => s.Role)
            .HasForeignKey(s => s.RoleId);

            modelBuilder.Entity<UserInterestGroup>()
                .HasKey(cs => new { cs.UserId, cs.InterestGroupId });



            modelBuilder.Entity<UserInterestGroup>()
            .HasOne(cs => cs.Student)
            .WithMany(s => s.UserInterestGroup)
            .HasForeignKey(cs => cs.UserId);

            modelBuilder.Entity<UserInterestGroup>()
            .HasOne(cs => cs.InterestGroup)
            .WithMany(c => c.UserInterestGroup)
            .HasForeignKey(cs => cs.InterestGroupId);
        }
    }
}
