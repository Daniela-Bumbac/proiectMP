using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlatinumGym.Data;
using PlatinumGym.Models;

namespace PlatinumGym.Pages.Trainers
{
    public class DetailsModel : PageModel
    {
        private readonly PlatinumGym.Data.PlatinumGymContext _context;

        public DetailsModel(PlatinumGym.Data.PlatinumGymContext context)
        {
            _context = context;
        }

      public Trainer Trainer { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Trainer == null)
            {
                return NotFound();
            }

            var trainer = await _context.Trainer.FirstOrDefaultAsync(m => m.TrainerID == id);
            if (trainer == null)
            {
                return NotFound();
            }
            else 
            {
                Trainer = trainer;
            }
            return Page();
        }
    }
}
