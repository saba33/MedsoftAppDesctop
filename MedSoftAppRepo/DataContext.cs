using MedSoftAppRepo.Model;
using Microsoft.EntityFrameworkCore;

namespace MedSoftAppRepo
{
    public class DataContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Gender> Genders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-3SC2RIJ\\SQLEXPRESS; Database=MedSoftDB; integrated security=true; TrustServerCertificate=True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>()
                .HasMany(g => g.Patients)
                .WithOne(p => p.Gender)
                .HasForeignKey(p => p.GenderID);

            modelBuilder.Entity<Patient>()
             .Property(p => p.ID)
             .ValueGeneratedOnAdd();
        }
    }
}
