using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class OrderModel
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int ShipperId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }


        [Required]
        public DateTime RequiredDate { get; set; }

        [Required]
        public DateTime ShippedDate { get; set; }

        [Required]
        public int ShipVia { get; set; }

        [Required]
        public int Freight { get; set; }

        [Required]
        public String ShipName { get; set; }

        [Required]
        public String ShipAddress { get; set; }

        [Required]
        public String ShipCity { get; set; }

        [Required]
        public String ShipRegion { get; set; }

        [Required]
        public int ShipPostalCode { get; set; }

        [Required]
        public String Country { get; set; }
    
    }
}
