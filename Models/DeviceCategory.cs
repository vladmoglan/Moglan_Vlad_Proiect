using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moglan_Vlad_Proiect.Models
{
    public class DeviceCategory
    {
        public int ID { get; set; }
        public int DeviceID { get; set; }
        public Device Device { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
