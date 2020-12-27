using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Moglan_Vlad_Proiect.Data;
using Moglan_Vlad_Proiect.Models;

namespace Moglan_Vlad_Proiect.Pages.Devices
{
    public class DetailsModel : PageModel
    {
        private readonly Moglan_Vlad_Proiect.Data.Moglan_Vlad_ProiectContext _context;

        public DetailsModel(Moglan_Vlad_Proiect.Data.Moglan_Vlad_ProiectContext context)
        {
            _context = context;
        }

        public Device Device { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Device = await _context.Device.FirstOrDefaultAsync(m => m.ID == id);

            if (Device == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
