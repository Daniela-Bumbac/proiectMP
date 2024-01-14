using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlatinumGym.Data;
using PlatinumGym.Models;

namespace PlatinumGym.Pages.Appointments
{
    public class EditModel : PageModel
    {
        private readonly PlatinumGym.Data.PlatinumGymContext _context;

        public EditModel(PlatinumGym.Data.PlatinumGymContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Appointment Appointment { get; set; }
        public SelectList TrainersSelectList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Appointment = await _context.Appointment
               .Include(p => p.Trainer)
               .Include(p => p.Client)
               .Include(p => p.Subscription)
               .FirstOrDefaultAsync(m => m.ID == id);
            if (Appointment == null)
            {
                return NotFound();
            }
            ViewData["TrainerID"] = new SelectList(_context.Set<Trainer>(), "TrainerID", "TrainerName");
            ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ClientID", "ClientName");
            ViewData["SubscriptionID"] = new SelectList(_context.Set<Subscription>(), "SubscriptionID", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var appointmentToUpdate = await _context.Appointment
                .Include(p => p.Trainer)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (appointmentToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Appointment>(
                appointmentToUpdate,
                "Appointment",
                i => i.TrainerID, i => i.ClientID, i => i.SubscriptionID, i => i.Data, i => i.Ora))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                catch (DbUpdateException ex)
                {
                    // Poți să gestionezi eroarea într-un mod specific aici sau să o loghezi
                    ModelState.AddModelError("", $"Eroare la salvarea appointmentului: {ex.Message}");
                }
            }
            ViewData["TrainerID"] = new SelectList(_context.Trainer, "TrainerID", "TrainerName", appointmentToUpdate.TrainerID);
            ViewData["ClientID"] = new SelectList(_context.Client, "ClientID", "ClientName", appointmentToUpdate.ClientID);
            ViewData["SubscriptionID"] = new SelectList(_context.Subscription, "SubscriptionID", "Name", appointmentToUpdate.SubscriptionID);

            return Page();
        }
    }
}


