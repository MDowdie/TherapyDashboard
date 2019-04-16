using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TherapyDashboard.Areas.Identity.Data;
using TherapyDashboard.Models;
using TherapyDashboard.Models.Database;

namespace TherapyDashboard.Controllers
{
    [Authorize(Policy = "CanConductAssessments")]
    public class AssessmentsController : Controller
    {
        private readonly TherapyDashboardContext _context;
        public readonly UserManager<TherapyDashboardUser> _userManager;


        public AssessmentsController(TherapyDashboardContext context, UserManager<TherapyDashboardUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ConductCFARS(string EnrollmentId)
        {
            //ViewBag["EnrollmentId"] = EnrollmentId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ConductCFARS([Bind("Answer1,Answer2,Answer3,Answer4,Answer5,Answer6,Answer7,Answer8,Answer9,Answer10,Answer11,Answer12,Answer13,Answer14,Answer15,Answer16,Answer17,Answer18,Answer19,Answer20,Answer21,Answer22,Answer23,Answer24,Answer25,Answer26,Answer27,Answer28,Answer29,Answer30,Answer31,Answer32,Answer33,Answer34,Answer35,Answer36,Answer37,Answer38,Answer39,Answer40,Answer41,Answer42,Answer43,Answer44,Answer45,Answer46,Answer47,Answer48,Answer49,Answer50,Answer51,Answer52,Answer53,Answer54,Answer55,Answer56,Answer57,Answer58,Answer59,Answer60,Answer61,Answer62,Answer63,Answer64,Answer65,Answer66,Answer67,Answer68,Answer69,Answer70,Answer71,Answer72")] CFARSAssessment cfarsAssessment)
        {
            cfarsAssessment.ConductDate = DateTime.Today;
            cfarsAssessment.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;


            if (ModelState.IsValid)
            {
                _context.Add(cfarsAssessment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // todo : change redirect to "Thanks for filling out the assessment! Please pass back to etc.,etc."
            }
            return View(cfarsAssessment);
        }

        public IActionResult ViewCFARS(int id) // something the client would be allowed to view
        {
            return View(id); // todo: change to return View(instantiated object);
        }

        public IActionResult ViewCFARSDetails(int id) // with in depth scores, and heatmapped answers
        {
            return View(id); // todo: change to return View(instantiated object);
        }

        public IActionResult EditCFARS(int id) // client-comfy view, but with both clients and counselors in mind
        {
            return View(id); // todo: change to return View(instantiated object);
        }

        public IActionResult DeleteCFARS(int id) // admin-only; will use in-page Are You Sure 
        {
            return View(id); // todo: change to return View(instantiated object);
        }
























        public IActionResult ConductPPSR()
        {
            return View();
        }

        public IActionResult ConductPCL()
        {
            return View();
        }


    }
}