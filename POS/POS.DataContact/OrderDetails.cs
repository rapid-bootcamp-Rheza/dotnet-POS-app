using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_order_details")]
    public class OrderDetails
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Required]
        [Column("order_id")]
        public int OrderId { get; set; }

        public Orders Order { get; set; }

        [Required]
        [Column("product_id")]
        public int ProductId { get; set; }

        public Products Product { get; set; }

        [Required]
        [Column("unit_price")]
        public int UnitPrice { get; set; }

        [Required]
        [Column("quantity")]
        public int Quantity { get; set; }

        [Required]
        [Column("discount")]
        public int Discount { get; set; }

        public OrderDetails()
        {

        }
        public OrderDetails(POS.ViewModel.OrderDetailModel model)
        {
            OrderId = model.OrderId;
            ProductId = model.ProductId;
            UnitPrice = model.UnitPrice;
            Quantity= model.Quantity;
            Discount = model.Discount;
        }
    }
}
