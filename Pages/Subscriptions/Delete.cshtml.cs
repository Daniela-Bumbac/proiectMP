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
    public class DeleteModel : PageModel
    {
        private readonly PlatinumGym.Data.PlatinumGymContext _context;

        public DeleteModel(PlatinumGym.Data.PlatinumGymContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Subscription == null)
            {
                return NotFound();
            }
            var subscription = await _context.Subscription.FindAsync(id);

            if (subscription != null)
            {
                Subscription = subscription;
                _context.Subscription.Remove(Subscription);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
