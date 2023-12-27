using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace InventoryService.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public double Rating { get; set; }

        [Required]
        public string Thumbnail { get; set; }

        // [Required]
        // public string[] Images { get; set; }



        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Category { get; set; }



        [Required]
        public decimal Discount { get; set; }

        [Required]
        public string Company { get; set; }




    }
}