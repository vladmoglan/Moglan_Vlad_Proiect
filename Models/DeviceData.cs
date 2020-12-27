using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moglan_Vlad_Proiect.Models
{
    public class DeviceData
    {
        public IEnumerable<Device> Devices { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<DeviceCategory> DeviceCategories { get; set; }

    }
}
