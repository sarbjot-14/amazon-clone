using System.ComponentModel.DataAnnotations;

namespace ProductService.Dtos
{
    public class ProductCreateDto
    {

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