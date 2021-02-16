using Microsoft.EntityFrameworkCore;

namespace Database.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Doctor>()
                .HasMany(c => c.Prescriptions)
                .WithOne(e => e.Doctor!)
                .HasForeignKey(t=>t.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder
                .Entity<Prescription>()
                .HasMany(c => c.Medicines)
                .WithOne(e => e.Prescription!)
                .HasForeignKey(t => t.PrescriptionId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Doctor> Doctors { get; set; } = default!;
        public DbSet<Prescription> Prescriptions { get; set; } = default!;
        public DbSet<Medicine> Medicines { get; set; } = default!;
    }
}