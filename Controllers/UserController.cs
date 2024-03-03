using Microsoft.AspNetCore.Mvc;
using Brooder.Models;
using Microsoft.AspNetCore.Identity;
using Brooder.Controllers;

public class UserController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ILogger<UserController> _logger;
    private readonly IWebHostEnvironment _hostingEnvironment;

    public UserController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        ILogger<UserController> logger,
        IWebHostEnvironment hostingEnvironment) // Add IWebHostEnvironment to the constructor
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
        _hostingEnvironment = hostingEnvironment; // Initialize the IWebHostEnvironment
    }


    // ********** Registration **********
    [HttpGet]
    public IActionResult Register()
    {
        return View(new RegisterViewModel()); // Initialize an empty ViewModel for the GET request
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email, // Correct property name
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with password."); // Log the success
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
                _logger.LogWarning("User registration failed: {Error}", error.Description); // Log the error
            }
        }
        else
        {
            _logger.LogWarning("Registration model state is not valid.");
        }

        // If we got this far, something failed, redisplay form with the provided model
        return View(model);
    }

    // ********** Login **********
    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;

        if (ModelState.IsValid)
        {
            // Use Email for login
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
        }

        return View(model);
    }

    // ********** Logout **********
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }

    private IActionResult RedirectToLocal(string returnUrl)
    {
        if (Url.IsLocalUrl(returnUrl))
        {
            return Redirect(returnUrl);
        }
        else
        {
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
    // GET: User/EditProfile
    public async Task<IActionResult> EditProfile()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("Login"); // Redirect to the login page if the user is not logged in
        }

        // Create and return a view model for the user's profile populated with existing data
        var model = new EditProfileViewModel
        {
            Name = user.Name,
            Age = user.Age,
            Bio = user.Bio,
            ProfileImagePath = user.ProfileImagePath,
            BloodType = user.BloodType.ToString()

        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EditProfile(EditProfileViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            // Explicitly update the user's properties with the form values
            user.Name = model.Name; // Assuming there's a Name property
            user.Age = model.Age; // Assuming there's an Age property
            user.Bio = model.Bio; // Assuming there's a Bio property

            // Parse the BloodType from the model and update the user
            if (Enum.TryParse<BloodType>(model.BloodType, out BloodType parsedBloodType))
            {
                user.BloodType = parsedBloodType;
            }
            else
            {
                // If parsing fails, add a model error and return to the form
                ModelState.AddModelError(nameof(model.BloodType), "Invalid blood type.");
                return View(model);
            }

            // Handle the image upload
            if (model.ProfileImage != null && model.ProfileImage.Length > 0)
            {
                var uploadsDir = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                if (!Directory.Exists(uploadsDir))
                {
                    Directory.CreateDirectory(uploadsDir);
                }

                var fileName = Path.GetFileName(model.ProfileImage.FileName);
                var uniqueFileName = $"{Guid.NewGuid()}_{fileName}";
                var filePath = Path.Combine(uploadsDir, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ProfileImage.CopyToAsync(fileStream);
                }

                // Update the path to the user's profile image in your database
                user.ProfileImagePath = uniqueFileName; // This should be just the file name if it's saved directly under wwwroot/uploads
            }

            // Attempt to update the user in the database
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
        }

        // If we're here, something went wrong, redisplay the form
        return View(model);
    }




    // Other methods...
}