using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_orders")]
    public class Orders
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("orders_customerid")]
        public int CustomerId { get; set; }

        public Customers Customer { get; set; }

        [Column("orders_employeeid")]
        public int EmployeeId { get; set; }

        public Employees Employee { get; set; }

        [Column("orders_shipperid")]
        public int ShipperId { get; set; }

        public Shippers Shipper { get; set; }

        [Column("orders_date")]
        public DateTime OrderDate { get; set; }

        [Column("orders_required_date")]
        public DateTime RequiredDate { get; set; }

        [Column("orders_shipped_date")]
        public DateTime ShippedDate { get; set; }

        [Column("orders_ship_via")]
        public int ShipVia { get; set; }

        [Column("orders_freight")]
        public int Freight { get; set; }

        [Column("orders_ship_name")]
        public String ShipName { get; set; }

        [Column("orders_ship_address")]
        public String ShipAddress { get; set; }

        [Column("orders_ship_city")]
        public String ShipCity { get; set; }

        [Column("orders_ship_region")]
        public String ShipRegion { get; set; }

        [Column("orders_ship_postalcode")]
        public int ShipPostalCode { get; set; }

        [Column("orders_ship_country")]
        public String Country { get; set; }

        public ICollection<OrderDetails> OrderDetail { get; set; }
    }
}
