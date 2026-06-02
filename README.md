# Super Summer BBQ 2026 — Registration Portal

A clean, mobile-friendly web app for employees to register for the company's annual BBQ event, manage their own registration, and give admins basic visibility and management tools.

**Event:** Super Summer BBQ 2026 · July 10, 2026 · BV Campus (Building 3 & Building 8 warehouses parking area)

## Features

- **Landing page** — event details, live countdown, agenda, FAQ, registration count
- **Registration** — first/last name, department, employee ID, email, dietary preferences, shuttle to/back, guest option
- **Self-service** — view, edit, and cancel registration (Employee ID + email lookup)
- **Simulated email** — confirmation shown on screen and logged server-side
- **Admin dashboard** — stats, department breakdown, registration list, admin cancel

## Tech stack

- ASP.NET Core 8 MVC
- Entity Framework Core 8 + SQLite (SQL Server–ready)
- Bootstrap 5

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Quick start

```bash
git clone https://github.com/siyiwang93/SuperSummerBbq.git
cd SuperSummerBbq
dotnet restore
dotnet run
```

Open **http://localhost:5299** (or the URL shown in the terminal).

The SQLite database (`bbq_registrations.db`) is created automatically on first run via EF Core migrations.

## Configuration

Edit `appsettings.json`:

| Setting | Description |
|--------|-------------|
| `ConnectionStrings:DefaultConnection` | SQLite path (default: `Data Source=bbq_registrations.db`) |
| `Event:Name`, `Event:Date`, `Event:Location` | Event display settings |
| `Event:AdminKey` | Admin login key (default: `bbq-admin-2026`) |

## Usage

| Page | URL |
|------|-----|
| Home | `/` |
| Register | `/Registrations/Register` |
| Manage registration | `/Registrations/Lookup` |
| Admin | `/Admin` |

## Project structure

```
Controllers/     Home, Registrations, Admin
Models/          Entities and view models
Data/            DbContext and EF migrations
Services/        Registration, email simulation, admin auth
Views/           Razor views
wwwroot/         CSS, JS, Bootstrap
```

## Switching to SQL Server

1. Add package: `Microsoft.EntityFrameworkCore.SqlServer`
2. Update the connection string in `appsettings.json`
3. In `Program.cs`, replace `UseSqlite` with `UseSqlServer`
4. Create and apply a new migration

## Version history

| Tag | Description |
|-----|-------------|
| `v1-mvp` | Initial MVP — landing page, registration CRUD, admin dashboard |

Restore this snapshot:

```bash
git checkout v1-mvp
```

## License

Internal company event project — adjust as needed for your organization.