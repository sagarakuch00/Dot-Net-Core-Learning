using CRUDUsingEFCoreCodeFirst.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirst.Models.Entities
{

    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Column("ProductName", TypeName = "varchar")]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Range(0, 50000)]
        public int? Price { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }

}
