namespace ProductService.Dtos
{
    public class ProductReadDto
    {

        public int Id { get; set; }


        public string Name { get; set; }


        public double Price { get; set; }


        public string Description { get; set; }

        public double Rating { get; set; }

        public string ImageUrl { get; set; }
    }
}