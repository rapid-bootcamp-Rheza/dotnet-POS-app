using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_shipper")]
    public class Shippers
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("company_name")]
        public int CompanyName { get; set; }

        [Column("phone")]
        public int Phone { get; set; }
    }
}
