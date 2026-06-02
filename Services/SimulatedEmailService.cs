using chloew.Models;

namespace chloew.Services;

public class SimulatedEmailService(ILogger<SimulatedEmailService> logger) : IEmailService
{
    public string BuildConfirmationBody(Registration registration, EventSettings eventSettings)
    {
        var shuttleTo = registration.ShuttleToVenue ? "Yes" : "No";
        var shuttleBack = registration.ShuttleBack ? "Yes" : "No";
        var guest = registration.BringingGuest ? "Yes" : "No";
        var dietary = string.IsNullOrWhiteSpace(registration.DietaryPreferences)
            ? "None specified"
            : registration.DietaryPreferences;

        return $"""
            Subject: Registration Confirmed — {eventSettings.Name}

            Hi {registration.FirstName},

            You're registered for {eventSettings.Name}!

            Event Details
            -------------
            Date: {eventSettings.Date:dddd, MMMM d, yyyy}
            Time: {eventSettings.Date:h:mm tt}
            Location: {eventSettings.Location}

            Your Registration
            -----------------
            Name: {registration.FirstName} {registration.LastName}
            Employee ID: {registration.EmployeeId}
            Department: {registration.Department}
            Email: {registration.Email}
            Dietary Preferences: {dietary}
            Shuttle to venue: {shuttleTo}
            Shuttle back: {shuttleBack}
            Bringing a guest: {guest}
            Confirmation #: {registration.ConfirmationToken:N}

            Need to make changes? Visit the registration portal and use "Manage My Registration" with your Employee ID and email.

            See you at the BBQ!
            — Company Events Team
            """;
    }

    public Task SendConfirmationAsync(Registration registration, EventSettings eventSettings, CancellationToken ct = default)
    {
        var body = BuildConfirmationBody(registration, eventSettings);
        logger.LogInformation(
            "Simulated email sent to {Email} for registration {RegistrationId}:\n{Body}",
            registration.Email,
            registration.Id,
            body);
        return Task.CompletedTask;
    }
}