using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperSummerBbq.Data.Migrations;

[DbContext(typeof(ApplicationDbContext))]
[Migration("20260602190000_InitialCreate")]
partial class InitialCreate
{
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

        modelBuilder.Entity("SuperSummerBbq.Models.Registration", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("INTEGER");

            b.Property<bool>("BringingGuest")
                .HasColumnType("INTEGER");

            b.Property<Guid>("ConfirmationToken")
                .HasColumnType("TEXT");

            b.Property<string>("Department")
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("TEXT");

            b.Property<string>("DietaryPreferences")
                .HasMaxLength(500)
                .HasColumnType("TEXT");

            b.Property<string>("Email")
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("TEXT");

            b.Property<string>("EmployeeId")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("TEXT");

            b.Property<string>("FirstName")
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("TEXT");

            b.Property<bool>("IsCancelled")
                .HasColumnType("INTEGER");

            b.Property<string>("LastName")
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("TEXT");

            b.Property<DateTime>("RegisteredAt")
                .HasColumnType("TEXT");

            b.Property<bool>("ShuttleBack")
                .HasColumnType("INTEGER");

            b.Property<bool>("ShuttleToVenue")
                .HasColumnType("INTEGER");

            b.Property<DateTime?>("UpdatedAt")
                .HasColumnType("TEXT");

            b.HasKey("Id");

            b.HasIndex("EmployeeId")
                .IsUnique()
                .HasFilter("[IsCancelled] = 0");

            b.ToTable("Registrations");
        });
    }
}