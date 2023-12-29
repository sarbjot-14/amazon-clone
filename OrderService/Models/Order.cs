using System.ComponentModel.DataAnnotations;

namespace OrdersService.Models
{
    public class Order
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int UserId { get; set; }


        [Required]
        public decimal Total { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal ShippingCost { get; set; }

        [Required]
        public decimal Taxes { get; set; }


    }
}