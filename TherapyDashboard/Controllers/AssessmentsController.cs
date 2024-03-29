﻿using System;
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
        public IActionResult ConductCFARS(int EnrollmentId)
        {
            ViewBag.EnrollmentId = EnrollmentId;
            CFARSAssessment assessment = new CFARSAssessment();

            Enrollment enrollment = _context.Enrollments.Single(c => c.Id == EnrollmentId);
            assessment.EnrollmentID = EnrollmentId;
            assessment.Client = enrollment.Client;
            assessment.ClientID = enrollment.ClientId;


            return View(assessment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ConductCFARS(CFARSAssessment cfarsAssessment, string id)
        {
            Enrollment enrollment = _context.Enrollments.Single(c => c.Id == Int32.Parse(id));


            cfarsAssessment.ConductDate = DateTime.Now;
            cfarsAssessment.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value; // current logged in user's id
            cfarsAssessment.Client = enrollment.Client;
            cfarsAssessment.ClientID = enrollment.ClientId;
            cfarsAssessment.Enrollment = enrollment;
            cfarsAssessment.EnrollmentID = enrollment.Id;

            cfarsAssessment.Id = 0; // this is a wet bandaid solution. for some reason, the id here keeps being set in the form page to the enrollment's ID, which makes the SQL server pitch a hissy fit

            if (ModelState.IsValid)
            {
                
                _context.CFARSAssessments.Add(cfarsAssessment);
                enrollment.CFARSAssessments.Add(cfarsAssessment);
                _context.Enrollments.Update(enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // todo : change redirect to "Thanks for filling out the assessment! Please pass back to etc.,etc."
            }
            return View(cfarsAssessment);
        }

        public IActionResult ViewCFARS(int id) // something the client would be allowed to view
        {
            CFARSAssessment assessment = _context.CFARSAssessments.Single(c => c.Id == id);
            return View(assessment); // todo: change to return View(instantiated object);
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




        public IActionResult ConductPPSR(int EnrollmentId)
        {
            ViewBag.EnrollmentId = EnrollmentId;
            PPSRAssessment assessment = new PPSRAssessment();

            Enrollment enrollment = _context.Enrollments.Single(c => c.Id == EnrollmentId);
            assessment.EnrollmentID = EnrollmentId;
            assessment.Client = enrollment.Client;
            assessment.ClientID = enrollment.ClientId;


            return View(assessment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ConductPPSR(PPSRAssessment ppsrAssessment, int id)
        {
            Enrollment enrollment = _context.Enrollments.Single(c => c.Id == id);


            ppsrAssessment.ConductDate = DateTime.Now;
            ppsrAssessment.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value; // current logged in user's id
            ppsrAssessment.Client = enrollment.Client;
            ppsrAssessment.ClientID = enrollment.ClientId;
            ppsrAssessment.Enrollment = enrollment;
            ppsrAssessment.EnrollmentID = enrollment.Id;

            ppsrAssessment.Id = 0; // this is a wet bandaid solution. for some reason, the id here keeps being set in the form page to the enrollment's ID, which makes the SQL server pitch a hissy fit

            if (ModelState.IsValid)
            {

                _context.PPSRAssessments.Add(ppsrAssessment);
                enrollment.PPSRAssessments.Add(ppsrAssessment);
                _context.Enrollments.Update(enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // todo : change redirect to "Thanks for filling out the assessment! Please pass back to etc.,etc."
            }
            return View(ppsrAssessment);
        }
        public IActionResult ViewPPSR(int id) // something the client would be allowed to view
        {
            PPSRAssessment assessment = _context.PPSRAssessments.Single(c => c.Id == id);
            return View(assessment); // todo: change to return View(instantiated object);
        }

        public IActionResult ConductPCL(int EnrollmentId)
        {
            ViewBag.EnrollmentId = EnrollmentId;
            PCLAssessment assessment = new PCLAssessment();

            Enrollment enrollment = _context.Enrollments.Single(c => c.Id == EnrollmentId);
            assessment.EnrollmentID = EnrollmentId;
            assessment.Client = enrollment.Client;
            assessment.ClientID = enrollment.ClientId;


            return View(assessment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ConductPCL(PCLAssessment pclAssessment, int id)
        {
            Enrollment enrollment = _context.Enrollments.Single(c => c.Id == id);


            pclAssessment.ConductDate = DateTime.Now;
            pclAssessment.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value; // current logged in user's id
            pclAssessment.Client = enrollment.Client;
            pclAssessment.ClientID = enrollment.ClientId;
            pclAssessment.Enrollment = enrollment;
            pclAssessment.EnrollmentID = enrollment.Id;

            pclAssessment.Id = 0; // this is a wet bandaid solution. for some reason, the id here keeps being set in the form page to the enrollment's ID, which makes the SQL server pitch a hissy fit

            if (ModelState.IsValid)
            {

                _context.PCLAssessments.Add(pclAssessment);
                enrollment.PCLAssessments.Add(pclAssessment);
                _context.Enrollments.Update(enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // todo : change redirect to "Thanks for filling out the assessment! Please pass back to etc.,etc."
            }
            return View(pclAssessment);
        }
        public IActionResult ViewPCL(int id) // something the client would be allowed to view
        {
            PCLAssessment assessment = _context.PCLAssessments.Single(c => c.Id == id);
            return View(assessment); // todo: change to return View(instantiated object);
        }


    }
}