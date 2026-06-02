using SuperSummerBbq.Data;
using SuperSummerBbq.Models;
using Microsoft.EntityFrameworkCore;

namespace SuperSummerBbq.Services;

public class RegistrationService(ApplicationDbContext db) : IRegistrationService
{
    public Task<Registration?> GetActiveByEmployeeIdAsync(string employeeId, CancellationToken ct = default) =>
        db.Registrations
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.EmployeeId == employeeId.Trim() && !r.IsCancelled, ct);

    public Task<Registration?> GetActiveByCredentialsAsync(string employeeId, string email, CancellationToken ct = default) =>
        db.Registrations
            .AsNoTracking()
            .FirstOrDefaultAsync(r =>
                r.EmployeeId == employeeId.Trim() &&
                r.Email == email.Trim() &&
                !r.IsCancelled, ct);

    public Task<Registration?> GetByIdAsync(int id, CancellationToken ct = default) =>
        db.Registrations.FirstOrDefaultAsync(r => r.Id == id, ct);

    public async Task<(bool Success, Registration? Registration, string? Error)> CreateAsync(
        RegistrationFormViewModel model, CancellationToken ct = default)
    {
        var employeeId = model.EmployeeId.Trim();
        var existing = await GetActiveByEmployeeIdAsync(employeeId, ct);
        if (existing is not null)
            return (false, null, "An active registration already exists for this Employee ID. Use Manage Registration to update it.");

        var registration = model.ToEntity();
        registration.RegisteredAt = DateTime.UtcNow;
        registration.ConfirmationToken = Guid.NewGuid();

        db.Registrations.Add(registration);
        await db.SaveChangesAsync(ct);
        return (true, registration, null);
    }

    public async Task<(bool Success, string? Error)> UpdateAsync(
        int id, RegistrationFormViewModel model, CancellationToken ct = default)
    {
        var registration = await GetByIdAsync(id, ct);
        if (registration is null || registration.IsCancelled)
            return (false, "Registration not found or has been cancelled.");

        var employeeId = model.EmployeeId.Trim();
        var duplicate = await db.Registrations
            .AnyAsync(r => r.EmployeeId == employeeId && r.Id != id && !r.IsCancelled, ct);
        if (duplicate)
            return (false, "Another active registration already uses this Employee ID.");

        registration.FirstName = model.FirstName.Trim();
        registration.LastName = model.LastName.Trim();
        registration.Department = model.Department.Trim();
        registration.EmployeeId = employeeId;
        registration.Email = model.Email.Trim();
        registration.DietaryPreferences = string.IsNullOrWhiteSpace(model.DietaryPreferences)
            ? null
            : model.DietaryPreferences.Trim();
        registration.ShuttleToVenue = model.ShuttleToVenue;
        registration.ShuttleBack = model.ShuttleBack;
        registration.BringingGuest = model.BringingGuest;
        registration.UpdatedAt = DateTime.UtcNow;

        await db.SaveChangesAsync(ct);
        return (true, null);
    }

    public async Task<bool> CancelAsync(int id, CancellationToken ct = default)
    {
        var registration = await GetByIdAsync(id, ct);
        if (registration is null || registration.IsCancelled)
            return false;

        registration.IsCancelled = true;
        registration.UpdatedAt = DateTime.UtcNow;
        await db.SaveChangesAsync(ct);
        return true;
    }

    public Task<int> GetActiveCountAsync(CancellationToken ct = default) =>
        db.Registrations.CountAsync(r => !r.IsCancelled, ct);

    public async Task<AdminDashboardViewModel> GetAdminDashboardAsync(CancellationToken ct = default)
    {
        var active = await db.Registrations
            .Where(r => !r.IsCancelled)
            .OrderByDescending(r => r.RegisteredAt)
            .AsNoTracking()
            .ToListAsync(ct);

        var cancelled = await db.Registrations.CountAsync(r => r.IsCancelled, ct);

        return new AdminDashboardViewModel
        {
            TotalActive = active.Count,
            TotalCancelled = cancelled,
            ShuttleToCount = active.Count(r => r.ShuttleToVenue),
            ShuttleBackCount = active.Count(r => r.ShuttleBack),
            GuestCount = active.Count(r => r.BringingGuest),
            Registrations = active,
            DepartmentBreakdown = active
                .GroupBy(r => r.Department)
                .OrderByDescending(g => g.Count())
                .ToDictionary(g => g.Key, g => g.Count())
        };
    }
}