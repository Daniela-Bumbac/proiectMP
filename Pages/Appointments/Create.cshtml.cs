using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlatinumGym.Data;
using PlatinumGym.Models;

namespace PlatinumGym.Pages.Appointments
{
    public class CreateModel : PageModel
    {
        private readonly PlatinumGym.Data.PlatinumGymContext _context;

        public CreateModel(PlatinumGym.Data.PlatinumGymContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            ViewData["TrainerID"] = new SelectList(_context.Trainer, "TrainerID", "TrainerName"); 

            if (ViewData["ClientID"] == null)
            {
                var users = _context.Client.ToList();
                ViewData["ClientID"] = new SelectList(users, "ClientID", "ClientName");
            }
            if (ViewData["SubscriptionID"] == null)
            {
                var subscriptions = _context.Subscription.ToList();
                List<Subscription> myList = new List<Subscription>();
                Subscription s1 = new Subscription("Basic Memebership", "adesc1", 20);
                Subscription s2 = new Subscription("Premium Memebership", "adesc1", 230);
                Subscription s3 = new Subscription("Annual Memebership", "adesc1", 250);
                Subscription s4 = new Subscription("Student Memebership", "adesc1", 210);
                
                myList.Add(s1);
                myList.Add(s2);
                myList.Add(s3);
                myList.Add(s4);

                ViewData["SubscriptionID"] = new SelectList(myList, "SubscriptionID", "Name");
            }
            return Page();
        }
        /*public IActionResult OnGet()
        {
            ViewData["TrainerID"] = new SelectList(_context.Trainer, "ID", "TrainerName");
            if (ViewData["ClientID"] == null)
            {
                var clientii = _context.Client.ToList();
                ViewData["ClientID"] = new SelectList(clientii, "ID", "ClientName");
            }
            if (ViewData["SubscriptionID"] == null)
            {
                var abonamente = _context.Subscription.ToList();
                ViewData["SubscriptionID"] = new SelectList(abonamente, "ID", "Name");
            }
            return Page();*/


        

        [BindProperty]
        public Appointment Appointment { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Appointment == null)
            {
                return Page();
            }
            try
            {

                _context.Appointment.Add(Appointment);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                // Poți să gestionezi eroarea într-un mod specific aici sau să o loghezi
                ModelState.AddModelError("", $"Eroare la salvarea appointment-ului: {ex.Message}");
                return Page();
            }
        }
    }
}
