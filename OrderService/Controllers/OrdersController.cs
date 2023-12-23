using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersService.AsyncDataServices;
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
        private readonly IMessageBusClient _messageBusClient;

        public OrdersController(AppDbContext appDbContext, IMapper mapper, IMessageBusClient messageBusClient)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _messageBusClient = messageBusClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderReadDto>> GetOrders()
        {
            var orders = _appDbContext.Orders.ToList();

            return Ok(_mapper.Map<IEnumerable<OrderReadDto>>(orders));
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderCreateDto orderCreateDto)
        {
            if (orderCreateDto == null)
            {
                throw new ArgumentNullException();
            }
            Order newOrder = _mapper.Map<Order>(orderCreateDto);
            _appDbContext.Add(newOrder);
            _appDbContext.SaveChanges();

            //send async event
            try
            {
                var orderPublishedDto = _mapper.Map<OrderPublishedDto>(newOrder);

                orderPublishedDto.Event = "Order_Published";

                Console.WriteLine($"order published dto is {JsonSerializer.Serialize(orderPublishedDto)}");
                _messageBusClient.PublishNewOrder(orderPublishedDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not publish async {ex.Message}");
            }



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