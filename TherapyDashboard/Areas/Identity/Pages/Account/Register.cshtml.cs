using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TherapyDashboard.Areas.Identity.Data;

namespace TherapyDashboard.Areas.Identity.Pages.Account
{
    [Authorize(Policy ="CanEditAccounts")]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<TherapyDashboardUser> _signInManager;
        private readonly UserManager<TherapyDashboardUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<TherapyDashboardUser> userManager,
            SignInManager<TherapyDashboardUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Assigned Role")]
            public string Role { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            
        }

        public async Task CreateRoleIfDoesNotExist(string role)
        {
            bool role_does_exist = await _roleManager.RoleExistsAsync(role);
            if (!role_does_exist)
            {
                IdentityRole _Role = new IdentityRole(role);
                var asdf = await _roleManager.CreateAsync(_Role);
            }
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/Admin");
            if (ModelState.IsValid)
            {
                var user = new TherapyDashboardUser { UserName = Input.Email, Email = Input.Email, RequirePasswordResetOnNextLogin = true };
                var x = await _userManager.CreateAsync(user, Input.Password);
                await CreateRoleIfDoesNotExist(Input.Role);
                await CreateRoleIfDoesNotExist(RoleType.Pending);
                List<string> listOfRolesOfNewUser = new List<string>{ Input.Role, RoleType.Pending };
                var result = await _userManager.AddToRolesAsync(user, listOfRolesOfNewUser);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    /*var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme); */

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                       // $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
