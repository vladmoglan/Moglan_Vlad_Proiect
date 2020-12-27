using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Moglan_Vlad_Proiect.Data;
using Moglan_Vlad_Proiect.Models;

namespace Moglan_Vlad_Proiect.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Moglan_Vlad_Proiect.Data.Moglan_Vlad_ProiectContext _context;

        public IndexModel(Moglan_Vlad_Proiect.Data.Moglan_Vlad_ProiectContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
