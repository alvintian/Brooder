using CookAlongAcademy.Models;
using CookAlongAcademy.Services;
using Microsoft.AspNetCore.Mvc;
using System;

public class UserController : Controller
{
    private AuthenticationService _authService;

    public UserController(AuthenticationService authService)
    {
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
    }

    public IActionResult Login(string username, string password)
    {
        var user = _authService.Authenticate(username, password);
        if (user != null)
        {
            // For the purpose of example, passing the user to the "Dashboard" view. 
            // In real implementation, probably you'd set some session values or claims
            return View("Dashboard", user);
        }
        else
        {
            ModelState.AddModelError("", "Username or password is incorrect");
            return View("Login");
        }
    }

    public IActionResult Logout()
    {
        // Implement logout logic here, like clearing the session or claims
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Register(User user)
    {
        if (ModelState.IsValid)
        {
            bool registered = _authService.Register(user);
            if (registered)
            {
                // Implement what happens after successful registration, 
                // like sending a confirmation email, logging the user in, etc.
                return RedirectToAction("Dashboard");
            }
            else
            {
                ModelState.AddModelError("", "Could not register the user. Username or email might already be in use.");
            }
        }

        // If we got this far, something failed, redisplay the registration form
        return View("Register", user);
    }
}
