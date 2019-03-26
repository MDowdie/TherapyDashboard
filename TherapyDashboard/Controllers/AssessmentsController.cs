using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TherapyDashboard.Controllers
{
    [Authorize(Policy = "CanConductAssessments")]
    public class AssessmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CFARS()
        {
            return View();
        }

        public IActionResult PPSR()
        {
            return View();
        }

        public IActionResult PCL()
        {
            return View();
        }


    }
}