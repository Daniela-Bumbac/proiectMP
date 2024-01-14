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
    public class IndexModel : PageModel
    {
        private readonly PlatinumGym.Data.PlatinumGymContext _context;

        public IndexModel(PlatinumGym.Data.PlatinumGymContext context)
        {
            _context = context;
        }

        public IList<Trainer> Trainer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Trainer != null)
            {
                Trainer = await _context.Trainer.ToListAsync();
            }
        }
    }
}
