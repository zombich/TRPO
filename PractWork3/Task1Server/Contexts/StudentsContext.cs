using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Task3Server.Models;

namespace Task3Server.Contexts
{
    public class StudentsContext : DbContext
    {
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Category> Categories => Set<Category>();
        public StudentsContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=students.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Category)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
