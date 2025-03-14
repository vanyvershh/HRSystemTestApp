using HRSystemTestApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HRSystemTestApp
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        //public ApplicationDbContext() => Database.EnsureCreated();

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<HR> HRs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>()
                .HasOne(c => c.Vacancy)
                .WithMany(v => v.Candidates)
                .HasForeignKey(c => c.VacancyId);
            
            modelBuilder.Entity<Candidate>()
                .HasOne(c => c.HR)
                .WithMany(h => h.Candidates)
                .HasForeignKey(c => c.HRId);

            modelBuilder.Entity<Vacancy>()
                .HasOne(v => v.Department)
                .WithMany(d => d.Vacancies)
                .HasForeignKey(v => v.DepartmentId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=HRSystemTestApp.db");
        }
    }
}
