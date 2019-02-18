using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using TherapyDashboard.Models;
using TherapyDashboard.Models.Database;

namespace TherapyDashboard.Controllers
{
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
            Client client = await _context.Clients.FindAsync(id);
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
                // TODO: Add insert logic here
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

        // POST: Client/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Details(string id, [Bind("Id,RelationshipStatus,DateOfBirth")] Client client)
        {
            /*if (id != client.Id)
            {
                return NotFound();
            }*/ // they're allowed to update the client's recorded ID number.

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
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Client/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Client/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
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
}