using SuperSummerBbq.Models;
using SuperSummerBbq.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace SuperSummerBbq.Controllers;

public class RegistrationsController(
    IRegistrationService registrationService,
    IEmailService emailService,
    IOptions<EventSettings> eventOptions) : Controller
{
    private const string SessionRegistrationId = "MyRegistrationId";
    private EventSettings Event => eventOptions.Value;

    [HttpGet]
    public IActionResult Register() => View(new RegistrationFormViewModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegistrationFormViewModel model, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(model);

        var (success, registration, error) = await registrationService.CreateAsync(model, ct);
        if (!success)
        {
            ModelState.AddModelError(string.Empty, error!);
            return View(model);
        }

        await emailService.SendConfirmationAsync(registration!, Event, ct);
        HttpContext.Session.SetInt32(SessionRegistrationId, registration!.Id);
        return RedirectToAction(nameof(Confirmation), new { id = registration.Id });
    }

    [HttpGet]
    public IActionResult Lookup() => View(new LookupViewModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Lookup(LookupViewModel model, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(model);

        var registration = await registrationService.GetActiveByCredentialsAsync(
            model.EmployeeId, model.Email, ct);

        if (registration is null)
        {
            ModelState.AddModelError(string.Empty,
                "No active registration found for this Employee ID and email combination.");
            return View(model);
        }

        HttpContext.Session.SetInt32(SessionRegistrationId, registration.Id);
        return RedirectToAction(nameof(Details), new { id = registration.Id });
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id, CancellationToken ct)
    {
        if (!await CanAccessRegistration(id, ct))
            return RedirectToAction(nameof(Lookup));

        var registration = await registrationService.GetByIdAsync(id, ct);
        if (registration is null || registration.IsCancelled)
            return NotFound();

        return View(registration);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id, CancellationToken ct)
    {
        if (!await CanAccessRegistration(id, ct))
            return RedirectToAction(nameof(Lookup));

        var registration = await registrationService.GetByIdAsync(id, ct);
        if (registration is null || registration.IsCancelled)
            return NotFound();

        return View(RegistrationFormViewModel.FromEntity(registration));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, RegistrationFormViewModel model, CancellationToken ct)
    {
        if (!await CanAccessRegistration(id, ct))
            return RedirectToAction(nameof(Lookup));

        model.Id = id;
        if (!ModelState.IsValid)
            return View(model);

        var (success, error) = await registrationService.UpdateAsync(id, model, ct);
        if (!success)
        {
            ModelState.AddModelError(string.Empty, error!);
            return View(model);
        }

        var updated = await registrationService.GetByIdAsync(id, ct);
        if (updated is not null)
            await emailService.SendConfirmationAsync(updated, Event, ct);

        TempData["Success"] = "Your registration has been updated successfully.";
        return RedirectToAction(nameof(Details), new { id });
    }

    [HttpGet]
    public async Task<IActionResult> Cancel(int id, CancellationToken ct)
    {
        if (!await CanAccessRegistration(id, ct))
            return RedirectToAction(nameof(Lookup));

        var registration = await registrationService.GetByIdAsync(id, ct);
        if (registration is null || registration.IsCancelled)
            return NotFound();

        return View(registration);
    }

    [HttpPost, ActionName("Cancel")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CancelConfirmed(int id, CancellationToken ct)
    {
        if (!await CanAccessRegistration(id, ct))
            return RedirectToAction(nameof(Lookup));

        await registrationService.CancelAsync(id, ct);
        HttpContext.Session.Remove(SessionRegistrationId);
        TempData["Success"] = "Your registration has been cancelled. We hope to see you next year!";
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public async Task<IActionResult> Confirmation(int id, CancellationToken ct)
    {
        var registration = await registrationService.GetByIdAsync(id, ct);
        if (registration is null)
            return NotFound();

        var vm = new EmailConfirmationViewModel
        {
            Registration = registration,
            Event = Event,
            SimulatedEmailBody = emailService.BuildConfirmationBody(registration, Event)
        };
        return View(vm);
    }

    private Task<bool> CanAccessRegistration(int id, CancellationToken ct)
    {
        var sessionId = HttpContext.Session.GetInt32(SessionRegistrationId);
        return Task.FromResult(sessionId == id);
    }
}