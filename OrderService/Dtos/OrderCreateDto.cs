namespace OrdersService.Dto
{
    public class OrderCreateDto
    {

        public int ProductId { get; set; }


        public int UserId { get; set; }

        public decimal Total { get; set; }
        public int Quantity { get; set; }

        public decimal ShippingCost { get; set; }

        public decimal Taxes { get; set; }

    }
}