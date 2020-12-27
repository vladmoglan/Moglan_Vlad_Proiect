using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moglan_Vlad_Proiect.Data;
using Moglan_Vlad_Proiect.Models;

namespace Moglan_Vlad_Proiect.Pages.Devices
{
    public class CreateModel : DeviceCategoriesPageModel
    {
        private readonly Moglan_Vlad_Proiect.Data.Moglan_Vlad_ProiectContext _context;

        public CreateModel(Moglan_Vlad_Proiect.Data.Moglan_Vlad_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["SellerID"] = new SelectList(_context.Set<Seller>(), "ID", "SellerName");
            var device = new Device();
            device.DeviceCategories = new List<DeviceCategory>();
            PopulateAssignedCategoryData(_context, device);

            return Page();
        }

        [BindProperty]
        public Device Device { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newDevice = new Device();
            if (selectedCategories != null)
            {
                newDevice.DeviceCategories = new List<DeviceCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new DeviceCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newDevice.DeviceCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Device>(newDevice, "Device",
            i => i.Name, i => i.Manufacturer,
            i => i.Price, i => i.ReleaseDate, i => i.SellerID))
            {
                _context.Device.Add(newDevice);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newDevice);
            return Page();
        }
    }
}
