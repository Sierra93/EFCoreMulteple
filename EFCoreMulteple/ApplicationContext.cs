using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMulteple {
    /// <summary>
    /// Контекст для работы с БД
    /// </summary>
    class ApplicationContext : DbContext {
        public DbSet<Cource> Cources { get; set; }
        public DbSet<Student> Students { get; set; }
        public ApplicationContext() {
            // Если БД не создана, то создает ее
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<StudentCource>()
            .HasKey(t => new { t.StudentId, t.CourseId });

            modelBuilder.Entity<StudentCource>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCources)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCource>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCources)
                .HasForeignKey(sc => sc.CourseId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=relationsdb;Trusted_Connection=True;");
        }
    }
}
