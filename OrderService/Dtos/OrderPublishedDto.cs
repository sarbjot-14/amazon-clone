namespace OrdersService.Dto
{
    public class OrderPublishedDto
    {


        public int Id { get; set; }

        public string Name { get; set; }
        public string Event { get; set; }


        public int ProductId { get; set; }


        public int UserId { get; set; }

        public decimal Total { get; set; }
        public int Quantity { get; set; }

        public decimal ShippingCost { get; set; }

        public decimal Taxes { get; set; }





    }
}