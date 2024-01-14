using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlatinumGym.Models;

namespace PlatinumGym.Data
{
    public class PlatinumGymContext : DbContext
    {
        public PlatinumGymContext (DbContextOptions<PlatinumGymContext> options)
            : base(options)
        {
        }

        public DbSet<PlatinumGym.Models.Appointment> Appointment { get; set; } = default!;

        public DbSet<PlatinumGym.Models.Client>? Client { get; set; }

        public DbSet<PlatinumGym.Models.Trainer>? Trainer { get; set; }

        public DbSet<PlatinumGym.Models.Subscription>? Subscription { get; set; }
    }
}
