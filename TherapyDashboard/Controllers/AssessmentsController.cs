using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TherapyDashboard.Controllers
{
    public class AssessmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}