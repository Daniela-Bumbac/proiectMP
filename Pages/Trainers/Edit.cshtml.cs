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

namespace PlatinumGym.Pages.Trainers
{
    public class EditModel : PageModel
    {
        private readonly PlatinumGym.Data.PlatinumGymContext _context;

        public EditModel(PlatinumGym.Data.PlatinumGymContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Trainer Trainer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Trainer == null)
            {
                return NotFound();
            }

            var trainer =  await _context.Trainer.FirstOrDefaultAsync(m => m.TrainerID == id);
            if (trainer == null)
            {
                return NotFound();
            }
            Trainer = trainer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Trainer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainerExists(Trainer.TrainerID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TrainerExists(int id)
        {
          return (_context.Trainer?.Any(e => e.TrainerID == id)).GetValueOrDefault();
        }
    }
}
