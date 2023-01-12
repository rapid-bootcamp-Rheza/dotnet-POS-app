using POS.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_products")]
    public class Products
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("supplier_id")]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        [Required]
        [Column("category_id")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        [Column("products_quantity")]
        public int Quantity { get; set; }

        [Required]
        [Column("products_unit_price")]
        public int UnitPrice { get; set; }

        [Required]
        [Column("products_unit_stock")]
        public int UnitStock { get; set; }

        [Required]
        [Column("products_unit_order")]
        public int UnitOrder { get; set; }

        [Required]
        [Column("products_reorder")]
        public int Reorder { get; set; }

        [Required]
        [Column("products_discontinued")]
        public bool Discontinued { get; set; }

        
        public ICollection<OrderDetails> OrderDetail { get; set; }

        public Products()
        {

        }
        public Products(POS.ViewModel.ProductModel model)
        {
            SupplierId = model.SupplierId;
            CategoryId = model.CategoryId;
            Quantity = model.Quantity;
            UnitPrice = model.UnitPrice;
            UnitStock= model.UnitStock;
            UnitOrder = model.UnitOrder;
            Reorder = model.Reorder;
            Discontinued = model.Discontinued;
        }
    }
}
