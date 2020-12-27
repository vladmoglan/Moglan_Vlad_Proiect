using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moglan_Vlad_Proiect.Models;

namespace Moglan_Vlad_Proiect.Data
{
    public class Moglan_Vlad_ProiectContext : DbContext
    {
        public Moglan_Vlad_ProiectContext (DbContextOptions<Moglan_Vlad_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Moglan_Vlad_Proiect.Models.Device> Device { get; set; }

        public DbSet<Moglan_Vlad_Proiect.Models.Seller> Seller { get; set; }

        public DbSet<Moglan_Vlad_Proiect.Models.Category> Category { get; set; }
    }
}
