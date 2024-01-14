using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlatinumGym.Data;
using PlatinumGym.Models;

namespace PlatinumGym.Pages.Subscriptions
{
    public class DetailsModel : PageModel
    {
        private readonly PlatinumGym.Data.PlatinumGymContext _context;

        public DetailsModel(PlatinumGym.Data.PlatinumGymContext context)
        {
            _context = context;
        }

      public Subscription Subscription { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Subscription == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscription.FirstOrDefaultAsync(m => m.SubscriptionID == id);
            if (subscription == null)
            {
                return NotFound();
            }
            else 
            {
                Subscription = subscription;
            }
            return Page();
        }
    }
}
