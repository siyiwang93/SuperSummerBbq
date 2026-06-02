using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chloew.Data.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Registrations",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                Department = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                EmployeeId = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                Email = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                DietaryPreferences = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                ShuttleToVenue = table.Column<bool>(type: "INTEGER", nullable: false),
                ShuttleBack = table.Column<bool>(type: "INTEGER", nullable: false),
                BringingGuest = table.Column<bool>(type: "INTEGER", nullable: false),
                RegisteredAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                IsCancelled = table.Column<bool>(type: "INTEGER", nullable: false),
                ConfirmationToken = table.Column<Guid>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Registrations", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Registrations_EmployeeId",
            table: "Registrations",
            column: "EmployeeId",
            unique: true,
            filter: "[IsCancelled] = 0");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "Registrations");
    }
}