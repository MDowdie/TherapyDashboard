using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using TherapyDashboard.Models;
using TherapyDashboard.Models.Database;

namespace TherapyDashboard.Controllers
{
    [Authorize(Policy = "CanConductAssessments")]
    public class ClientsController : Controller
    {
        private readonly TherapyDashboardContext _context;

        public ClientsController(TherapyDashboardContext context)
        {
            _context = context;
        }

        // GET: Client
        public async Task<ActionResult> Index()
        {
            return View(await _context.Clients.ToListAsync());
        }

        // GET: Client/Details/5
        public async Task<ActionResult> Details(string id)
        {
            //Client client = await _context.Clients.FindAsync(id);

            Client client = _context.Clients.Single(c => c.Id == id);
            _context.Entry(client).Collection(c => c.Enrollments).Load();


            return View(client);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id")] Client client)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    _context.Add(client);
                    var x = await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(client);
                }
            }
            catch
            {
                //TODO return error message
                return View(client);
            }
        }

        public ActionResult AssignRace(string ClientId, string race)
        {
            Client ClientInQuestion = _context.Clients.Find(ClientId);

            ClientInQuestion.Race = race;
            _context.Clients.Update(ClientInQuestion);
            _context.SaveChanges();
            string outputurl = "~/Clients/Details/" + ClientId;

            return Redirect(outputurl);
        }

        public ActionResult AssignEthnicity(string ClientId, string ethnicity)
        {
            Client ClientInQuestion = _context.Clients.Find(ClientId);

            ClientInQuestion.Ethnicity = ethnicity;
            _context.Clients.Update(ClientInQuestion);
            _context.SaveChanges();
            string outputurl = "~/Clients/Details/" + ClientId;

            return Redirect(outputurl);
        }

        public ActionResult AssignGender(string ClientId, string gender)
        {
            Client ClientInQuestion = _context.Clients.Find(ClientId);

            ClientInQuestion.Gender = gender;
            _context.Clients.Update(ClientInQuestion);
            _context.SaveChanges();
            string outputurl = "~/Clients/Details/" + ClientId;

            return Redirect(outputurl);
        }

        public ActionResult EnrollInProgram(string id, string program)
        {
            Client ClientInQuestion = _context.Clients.Find(id);

            bool enrollmentAlreadyExists = false;
            if (ClientInQuestion.Enrollments != null)
            {
                foreach (var i_enroll in ClientInQuestion.Enrollments)
                {
                    if (i_enroll.ParticipatingIn == program)
                    {
                        enrollmentAlreadyExists = true;
                        break;
                    }
                }
            }
            if (!enrollmentAlreadyExists)
            {
                Enrollment enrollment = new Enrollment();
                enrollment.ParticipatingIn = program;
                enrollment.Client = ClientInQuestion;
                enrollment.Start = DateTime.Today;

                _context.Enrollments.Add(enrollment);
                ClientInQuestion.Enrollments.Add(enrollment);

                _context.SaveChanges();
            }
            string outputurl = "~/Clients/Details/" + id;
            return Redirect(outputurl);
        }

        public ActionResult DeleteEnrollment(int id, string client)
        {
            Enrollment EnrollmentInQuestion = _context.Enrollments.Find(id);
            Client ClientInQuestion = _context.Clients.Find(client);
            if (EnrollmentInQuestion != null)
            {
                if(EnrollmentInQuestion.Client != null)
                {
                    //EnrollmentInQuestion.ClientId = null;
                    ClientInQuestion.Enrollments.Remove(EnrollmentInQuestion);
                    //_context.Enrollments.Remove(EnrollmentInQuestion);
                    _context.SaveChanges();
                }
            }

            string outputurl = "~/Clients/Details/" + client;
            return Redirect(outputurl);
        }

        public ActionResult EndEnrollment(int id, string client)
        {
            Enrollment EnrollmentInQuestion = _context.Enrollments.Find(id);
            EnrollmentInQuestion.End = DateTime.Today;

            _context.SaveChanges();


            string outputurl = "~/Clients/Details/" + client;
            return Redirect(outputurl);
        }



        // POST: Client/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Details(string id, [Bind("Id,Race,Ethnicity,Gender,RelationshipStatus,PartnerGender,DateOfBirth")] Client client)
        {
            /*if (id != client.Id)
            {
                return NotFound();
            }*/ // this is commented out because users are allowed to update the client's recorded ID number.


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Clients.Any(e => e.Id == id)) // if there are no clients by that id to update
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return View(client);
            }
            return View(client);
        }

        // POST: Client/Delete/5
        //[Authorize(Policy = "CanEditAccounts")]
        public ActionResult Delete(string id)
        {
            try
            {
                // TODO: Add delete logic here
                Client ClientInQuestion = _context.Clients.Find(id);
                _context.Clients.Remove(ClientInQuestion);
                _context.SaveChanges();



                return RedirectToAction(nameof(Index));
            }
            catch
            {
                string outputurl = "~/Clients/Details/" + id;
                return Redirect(outputurl);
            }
        }

    }
}