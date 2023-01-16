using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class CustomerModel
    {
        public int Id { get; set; }

        [Required]
        public String CompanyName { get; set; }

        [Required]
        public String CustomerName { get; set; }

        [Required]
        public String ContactTitle { get; set; }

        [Required]
        public String Address { get; set; }

        [Required]
        public String City { get; set; }

        [Required]
        public String Region { get; set; }

        [Required]
        public String PostalCode { get; set; }

        [Required]
        public String Country { get; set; }

        [Required]
        public int Phone { get; set; }

        [Required]
        public int Fax { get; set; }


    }
}
