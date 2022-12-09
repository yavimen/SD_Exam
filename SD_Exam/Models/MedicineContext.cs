using Microsoft.EntityFrameworkCore;

namespace SD_Exam.Models
{
    public class MedicineContext:DbContext
    {
        protected string connectionString = "Server=VICTOR\\MSSQLSERVER2019;Database=Medicine;Trusted_Connection=true;";

        public MedicineContext()
        {

        }

        public DbSet<Medicine> Medicines { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedOnAdd().IsRequired(true);

                entity.Property(e => e.Title).HasMaxLength(50).IsRequired(true);

                entity.Property(e => e.Dose).IsRequired(true);

                entity.Property(e => e.Description).HasMaxLength(100).IsRequired(true);

                entity.Property(e => e.Amount).IsRequired(true);
            });

            modelBuilder.Entity<Medicine>().HasData(
                new Medicine
                {
                    ID = 1,
                    Title = "Analgin",
                    Dose = 2.5,
                    Description = "When headache",
                    Amount = 100
                },
                new Medicine
                {
                    ID = 2,
                    Title = "Varfaryn",
                    Dose = 5,
                    Description = "Good for blood",
                    Amount = 200
                },
                new Medicine
                {
                    ID = 3,
                    Title = "Nurofen",
                    Dose = 0.1,
                    Description = "When cold",
                    Amount = 50
                }
            );
        }
    }
}
