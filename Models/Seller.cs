using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moglan_Vlad_Proiect.Models
{
    public class Seller
    {
        public int ID { get; set; }
        public string SellerName { get; set; }
        public ICollection<Device> Devices { get; set; }
    }
}
