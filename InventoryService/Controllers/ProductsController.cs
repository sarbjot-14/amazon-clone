using System.Text.Json;
using AutoMapper;
using InventoryService.Models;
using InventoryService.Services;

// using InventoryService.Services;
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
        private readonly ICacheService _cacheService;

        public ProductsController(IProductRepo repository, IMapper mapper, ICacheService cacheService)
        {
            _repository = repository;
            _mapper = mapper;
            _cacheService = cacheService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetProducts()
        {

            // if null then get products and populate cache then return 

            // if not null then convert from cache and return
            var value = await _cacheService.GetCacheValueAsync("products");
            if (value == null)
            {
                Console.WriteLine("cache empty");
                Console.WriteLine("--> Getting Products (hitting database)");
                var productItems = _repository.GetProducts();


                await _cacheService.SetCacheValueAsync("products", JsonSerializer.Serialize(productItems));
                return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(productItems));

            }
            else
            {
                return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(JsonSerializer.Deserialize<Product[]>(value)));
            }

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
        public async Task<ActionResult<ProductReadDto>> CreateProduct(ProductCreateDto productCreateDto)
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