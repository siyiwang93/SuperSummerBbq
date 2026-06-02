using SuperSummerBbq.Models;
using Microsoft.EntityFrameworkCore;

namespace SuperSummerBbq.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Registration> Registrations => Set<Registration>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Registration>(entity =>
        {
            entity.HasIndex(r => r.EmployeeId)
                .IsUnique()
                .HasFilter("[IsCancelled] = 0");

            entity.Property(r => r.FirstName).HasMaxLength(100);
            entity.Property(r => r.LastName).HasMaxLength(100);
            entity.Property(r => r.Department).HasMaxLength(100);
            entity.Property(r => r.EmployeeId).HasMaxLength(50);
            entity.Property(r => r.Email).HasMaxLength(200);
            entity.Property(r => r.DietaryPreferences).HasMaxLength(500);
        });
    }
}