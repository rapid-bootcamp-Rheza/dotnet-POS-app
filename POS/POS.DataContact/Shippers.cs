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

        [Required]
        [Column("company_name")]
        public String CompanyName { get; set; }

        [Required]
        [Column("phone")]
        public int Phone { get; set; }

        public Shippers()
        {

        }

        public Shippers(POS.ViewModel.ShipperModel model)
        {
            CompanyName = model.CompanyName;
            Phone = model.Phone;
        }
    }
}
