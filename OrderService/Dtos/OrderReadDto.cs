namespace OrdersService.Dto
{

    public class OrderReadDto
    {


        public int Id { get; set; }

        public int ProductId { get; set; }


        public int UserId { get; set; }



        public decimal Total { get; set; }

    }
}
