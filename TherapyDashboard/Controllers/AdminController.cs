using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TherapyDashboard.Areas.Identity.Data;
using TherapyDashboard.Models;
using Microsoft.AspNetCore.Authorization;

namespace TherapyDashboard.Controllers
{
    public class AdminController : Controller
    {
        #region toolbox setup
        private readonly UserManager<TherapyDashboardUser> _userManager;
        private readonly TherapyDashboardContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(TherapyDashboardContext context, UserManager<TherapyDashboardUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        #endregion

        // GET: Admin
        [Authorize(Roles = RoleType.Admin)]
        public async Task<ActionResult> Index()
        {
            //create a dictionary of all roles a user has. Since in this Therapy Dashboard, a user can have a max of one role, the array of roles returned is reduced to null (if empty array) or a single element as a dictionary value. Key is user id.
            var listOfAllUsers = _context.Users.ToList<TherapyDashboardUser>();
            Dictionary<string, string> UserRole = new Dictionary<string, string>();
            foreach (var user in listOfAllUsers)
            {
                IList<string> x = await _userManager.GetRolesAsync(user);
                if (x.Count == 0)
                {
                    UserRole.Add(user.Id, null);
                } else
                {
                    UserRole.Add(user.Id, x.First());
                }
            }
            ViewBag.UserRole = UserRole;
            return View(listOfAllUsers);
        }

        /// <summary>
        /// Assigns a role to a given user, based on id. Creates the role if it doesn't already have an entry in the database. Removes any other role that user has before applying new one, if there's a change.
        /// 
        /// Note that role changes don't apply to a user until the next time they log in. They keep their previous permissions for so long as they are currently logged in, whether as Admin or as Intern, until they reset things server-side.
        /// </summary>
        /// <param name="id">The given user's ID string.</param>
        /// <param name="role">The name of the role. Strongly recommend using RoleType.NameOfRole in order to prevent typos adding extra roles.</param>
        /// <returns>Sends user to homeurl/Admin/Index, as though refresh.</returns>
        [Authorize(Roles = RoleType.Admin)]
        public async Task<ActionResult> AssignRole(string id, string role)
        {
            var CurrentUser = await _userManager.FindByIdAsync(id);
            //create role if does not exist
            bool role_does_exist = await _roleManager.RoleExistsAsync(role);
            if (!role_does_exist)
            {
                IdentityRole _Role = new IdentityRole(role);
                var asdf = await _roleManager.CreateAsync(_Role);
            }

            //remove other roles before applying new one
            var fdsa = await _userManager.RemoveFromRolesAsync(CurrentUser, await _userManager.GetRolesAsync(CurrentUser));


            //apply new role
            var x = await _userManager.AddToRoleAsync(await _userManager.FindByIdAsync(id), role);
            return RedirectToAction(nameof(Index));
        }



        #region CRUD todo's
        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
    #endregion
}