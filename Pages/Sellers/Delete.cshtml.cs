﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Moglan_Vlad_Proiect.Data;
using Moglan_Vlad_Proiect.Models;

namespace Moglan_Vlad_Proiect.Pages.Sellers
{
    public class DeleteModel : PageModel
    {
        private readonly Moglan_Vlad_Proiect.Data.Moglan_Vlad_ProiectContext _context;

        public DeleteModel(Moglan_Vlad_Proiect.Data.Moglan_Vlad_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Seller Seller { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Seller = await _context.Seller.FirstOrDefaultAsync(m => m.ID == id);

            if (Seller == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Seller = await _context.Seller.FindAsync(id);

            if (Seller != null)
            {
                _context.Seller.Remove(Seller);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
