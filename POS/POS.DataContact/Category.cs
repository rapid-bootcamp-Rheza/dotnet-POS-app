using POS.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Repository
{
    [Table("tbl_category")]
    public class Category
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("category_name")]
        public String CategoryName { get; set; }

        [Required]
        [Column("category_desc")]
        public String Description { get; set; }

        public ICollection<Products> Product { get; set; }

        public Category()
        {

        }
        public Category(POS.ViewModel.CategoryModel model)
        {
            CategoryName = model.CategoryName;
            Description = model.Description;
        }

    }
}