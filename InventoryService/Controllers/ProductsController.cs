using System.Text.Json;
using AutoMapper;
using InventoryService.Models;
using Microsoft.AspNetCore.Mvc;
using ProductService.Data;
using ProductService.Dtos;

namespace ProductsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _repository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetProducts()
        {
            Console.WriteLine("--> Getting Products");

            var productItems = _repository.GetProducts();

            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(productItems));
        }
        [HttpGet("{id}", Name = "GetProductById")]
        public ActionResult<ProductReadDto> GetProductById(int id)
        {
            var productItem = _repository.GetProductById(id);

            if (productItem != null)
            {
                return Ok(_mapper.Map<ProductReadDto>(productItem));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public void DeleteProducts()
        {
            _repository.DeleteProducts();
        }

        [HttpPost]
        public ActionResult<ProductReadDto> CreateProduct(ProductCreateDto productCreateDto)
        {
            var product = _mapper.Map<Product>(productCreateDto);
            //Console.WriteLine($"just seeting here {JsonSerializer.Serialize(product)}");
            _repository.CreateProduct(product);
            _repository.SaveChanges();

            var productReadDto = _mapper.Map<ProductReadDto>(product);

            return CreatedAtRoute(nameof(GetProductById), new { Id = productReadDto.Id }, productReadDto);
        }

    }


}