using SuperSummerBbq.Models;
using SuperSummerBbq.Services;
using Microsoft.AspNetCore.Mvc;

namespace SuperSummerBbq.Controllers;

public class AdminController(
    AdminAuthService adminAuth,
    IRegistrationService registrationService) : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        if (adminAuth.IsAuthenticated)
            return RedirectToAction(nameof(Index));

        return View(new AdminLoginViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(AdminLoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        if (!adminAuth.TryLogin(model.AccessKey))
        {
            ModelState.AddModelError(string.Empty, "Invalid admin access key.");
            return View(model);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken ct)
    {
        if (!adminAuth.IsAuthenticated)
            return RedirectToAction(nameof(Login));

        var dashboard = await registrationService.GetAdminDashboardAsync(ct);
        return View(dashboard);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Logout()
    {
        adminAuth.Logout();
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CancelRegistration(int id, CancellationToken ct)
    {
        if (!adminAuth.IsAuthenticated)
            return RedirectToAction(nameof(Login));

        await registrationService.CancelAsync(id, ct);
        TempData["Success"] = "Registration cancelled by admin.";
        return RedirectToAction(nameof(Index));
    }
}