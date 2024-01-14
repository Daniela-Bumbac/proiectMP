using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlatinumGym.Data;
using PlatinumGym.Models;

namespace PlatinumGym.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly PlatinumGym.Data.PlatinumGymContext _context;

        public IndexModel(PlatinumGym.Data.PlatinumGymContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get;set; }
        public string TrainerSort { get; set; }
        public string ClientSort { get; set; }
        public string SubscriptionSort { get; set; }
        public async Task OnGetAsync()
        {
            if (_context.Appointment != null)
            {
                IQueryable<Appointment> appointmentsQuery = _context.Appointment
                 .Include(p => p.Trainer)  
                 .Include(p => p.Client)
                 .Include(p => p.Subscription);

                Appointment = await appointmentsQuery.ToListAsync();

            }
        }
    }
}
