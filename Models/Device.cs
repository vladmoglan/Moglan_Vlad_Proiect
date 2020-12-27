using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Moglan_Vlad_Proiect.Models
{
    public class Device
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "ProductName")]
        public string Name { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele producatorului trebuie sa fie de forma 'Nume Tip'."), Required, StringLength(50, MinimumLength = 2)]
        public string Manufacturer { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public int SellerID { get; set; }
        public Seller Seller { get; set; }
        public ICollection<DeviceCategory> DeviceCategories { get; set; }

    }
}

