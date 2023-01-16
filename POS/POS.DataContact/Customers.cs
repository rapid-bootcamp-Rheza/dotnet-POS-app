using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_customer")]
    public class Customers
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public String CustomerName { get; set; }

        [Required]
        [Column("company_name")]
        public String CompanyName { get; set; }

        [Required]
        [Column("contact_title")]
        public String ContactTitle { get; set; }

        [Required]
        [Column("address")]
        public String Address { get; set; }

        [Required]
        [Column("city")]
        public String City { get; set; }

        [Required]
        [Column("region")]
        public String Region { get; set; }

        [Required]
        [Column("postalcode")]
        public String PostalCode { get; set; }

        [Required]
        [Column("country")]
        public String Country { get; set; }

        [Required]
        [Column("phone")]
        public int Phone { get; set; }

        [Required]
        [Column("fax")]
        public int Fax { get; set; }

        [Required]
        public ICollection<Orders> Order { get; set; }


        public Customers()
        {

        }
        public Customers(POS.ViewModel.CustomerModel model)
        {
            CustomerName = model.CustomerName;
            CompanyName = model.CompanyName;
            ContactTitle = model.ContactTitle;
            Address = model.Address;
            City = model.City;
            Region = model.Region;
            PostalCode = model.PostalCode;
            Country = model.Country;
            Phone = model.Phone;
            Fax = model.Fax;
        }

    }
}
