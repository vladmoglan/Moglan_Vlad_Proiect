using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Moglan_Vlad_Proiect.Data;
using Moglan_Vlad_Proiect.Models;

namespace Moglan_Vlad_Proiect.Pages.Devices
{
    public class EditModel : DeviceCategoriesPageModel

    {
        private readonly Moglan_Vlad_Proiect.Data.Moglan_Vlad_ProiectContext _context;

        public EditModel(Moglan_Vlad_Proiect.Data.Moglan_Vlad_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Device Device { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Device = await _context.Device
                .Include(b => b.Seller)
                .Include(b => b.DeviceCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Device == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Device);
            ViewData["SellerID"] = new SelectList(_context.Set<Seller>(), "ID", "SellerName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var deviceToUpdate = await _context.Device
            .Include(i => i.Seller)
            .Include(i => i.DeviceCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (deviceToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Device>(deviceToUpdate, "Device",
            i => i.Name, i => i.Manufacturer,
            i => i.Price, i => i.ReleaseDate, i => i.Seller))
            {
                UpdateDeviceCategories(_context, selectedCategories, deviceToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateDeviceCategories(_context, selectedCategories, deviceToUpdate);
            PopulateAssignedCategoryData(_context, deviceToUpdate);
            return Page();
        }
    }
}
