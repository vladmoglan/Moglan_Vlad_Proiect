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
    public class IndexModel : PageModel
    {
        private readonly Moglan_Vlad_Proiect.Data.Moglan_Vlad_ProiectContext _context;

        public IndexModel(Moglan_Vlad_Proiect.Data.Moglan_Vlad_ProiectContext context)
        {
            _context = context;
        }

        public IList<Device> Device { get;set; }

        public DeviceData DeviceD { get; set; }
        public int DeviceID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            DeviceD = new DeviceData();

            DeviceD.Devices = await _context.Device
            .Include(b => b.Seller)
            .Include(b => b.DeviceCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
            if (id != null)
            {
                DeviceID = id.Value;
                Device device = DeviceD.Devices
                .Where(i => i.ID == id.Value).Single();
                DeviceD.Categories = device.DeviceCategories.Select(s => s.Category);
            }
        }

    }
}
