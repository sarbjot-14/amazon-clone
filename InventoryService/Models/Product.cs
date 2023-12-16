using System.ComponentModel.DataAnnotations;

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
        public string ImageUrl { get; set; }
    }
}