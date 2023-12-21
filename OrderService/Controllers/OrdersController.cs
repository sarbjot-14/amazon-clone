using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersService.Data;
using OrdersService.Dto;
using OrdersService.Models;
using OrdersService.Profiles;

namespace OrdersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private AppDbContext _appDbContext;
        private IMapper _mapper;

        public OrdersController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderReadDto>> GetOrders()
        {
            var orders = _appDbContext.Orders.ToList();
            Console.WriteLine("returning it  {0}", JsonSerializer.Serialize(orders));

            return Ok(_mapper.Map<IEnumerable<OrderReadDto>>(orders));
        }

        [HttpPost]
        public ActionResult<Order> CreateOrder(OrderCreateDto orderCreateDto)
        {
            if (orderCreateDto == null)
            {
                throw new ArgumentNullException();
            }
            Order newOrder = _mapper.Map<Order>(orderCreateDto);
            _appDbContext.Add(newOrder);
            _appDbContext.SaveChanges();

            Console.WriteLine("created it {0}", JsonSerializer.Serialize(newOrder));

            return Ok(newOrder);
        }

        [HttpGet("{id}", Name = "GetOrderById")]
        public ActionResult<OrderReadDto> GetOrderById(int id)
        {
            var order = _appDbContext.Orders.Where(o => o.Id == id).FirstOrDefault<Order>();

            if (order != null)
            {
                return Ok(_mapper.Map<OrderReadDto>(order));
            }
            else
            {
                return NotFound();
            }
        }




    }
}