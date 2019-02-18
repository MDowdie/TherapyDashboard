using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TherapyDashboard.Areas.Identity.Data;
using TherapyDashboard.Models;

namespace TherapyDashboard.Controllers
{
    [Authorize(Policy="AnyValidUser")]
    public class HomeController : Controller
    {
        public readonly UserManager<TherapyDashboardUser> _userManager;
        public readonly SignInManager<TherapyDashboardUser> _signInManager;
        public readonly RoleManager<IdentityRole> _roleManager;
        

        public HomeController(UserManager<TherapyDashboardUser> userManager, SignInManager<TherapyDashboardUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            RoleType.SeedInitialUsers(_userManager, _roleManager).Wait();
        }

        public async Task<IActionResult> Index()
        {
            
            //if, on next login, the user is required to change their password, redirect them directly to the password change page
            if (User.Identity.IsAuthenticated) // if user logged in
            {
                var CurrentLoggedInUser = await _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (CurrentLoggedInUser.RequirePasswordResetOnNextLogin)
                {
                    string request = HttpContext.Request.PathBase.ToString() + "/Identity/Account/Manage/ChangePassword";
                    return Redirect(request);
                }
            }
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            //if, on next login, the user is required to change their password, redirect them directly to the password change page
            if (User.Identity.IsAuthenticated) // if user logged in
            {
                var CurrentLoggedInUser = await _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (CurrentLoggedInUser.RequirePasswordResetOnNextLogin)
                {
                    string request = HttpContext.Request.PathBase.ToString() + "/Identity/Account/Manage/ChangePassword";
                    return Redirect(request);
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
