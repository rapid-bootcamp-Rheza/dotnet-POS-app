using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_supplier")]
    public class Supplier
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("supplier_company_name")]
        public String CompanyName { get; set; }

        [Required]
        [Column("supplier_contact_name")]
        public String ContactName { get; set; }

        [Required]
        [Column("supplier_contact_title")]
        public String ContactTitle { get; set; }

        [Required]
        [Column("supplier_address")]
        public String Address { get; set; }

        [Required]
        [Column("supplier_city")]
        public String City { get; set; }

        [Required]
        [Column("supplier_region")]
        public String Region { get; set; }

        [Required]
        [Column("supplier_postalcode")]
        public String PostalCode { get; set; }

        [Required]
        [Column("supplier_country")]
        public String Country { get; set; }

        [Required]
        [Column("supplier_phone")]
        public int Phone { get; set; }

        [Required]
        [Column("supplier_fax")]
        public int Fax { get; set; }

        [Required]
        [Column("supplier_homepage")]
        public String HomePage { get; set; }

        public ICollection<Products> Product { get; set; }

        public Supplier()
        {

        }
        public Supplier(POS.ViewModel.SupplierModel model)
        {
            CompanyName = model.CompanyName;
            ContactName = model.ContactName;
            ContactTitle =   model.ContactTitle; ;
            Address = model.Address;
            City = model.City;
            Region = model.Region;
            PostalCode = model.PostalCode;
            Country = model.Country;
            Phone = model.Phone;
            Fax = model.Fax;
            HomePage = model.HomePage;

        }
    }
}
