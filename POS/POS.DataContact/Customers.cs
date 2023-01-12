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

        [Column("name")]
        public String CustomerName { get; set; }

        [Column("company_name")]
        public String CompanyName { get; set; }

        [Column("contact_title")]
        public String ContactTitle { get; set; }

        [Column("address")]
        public String Address { get; set; }

        [Column("city")]
        public String City { get; set; }

        [Column("region")]
        public String Region { get; set; }

        [Column("postalcode")]
        public String PostalCode { get; set; }

        [Column("country")]
        public String Country { get; set; }

        [Column("phone")]
        public int Phone { get; set; }

        [Column("fax")]
        public int Fax { get; set; }

        public ICollection<Orders> Order { get; set; }


    }
}
