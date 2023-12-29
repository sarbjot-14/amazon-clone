using System.Text.Json;
using AutoMapper;
using InventoryService.Dto;
using InventoryService.Models;
using ProductService.Data;
using ProductService.EventProcessing;

namespace InventoryService.EventProcessing
{
    public class EventProcesing : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcesing(IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }


        public void ProcessEvent(string message)
        {
            var eventType = DeterminedEvent(message);

            switch (eventType)
            {
                case EventType.OrderPublished:
                    addOrder(message);
                    break;
                default:
                    break;
            }
        }

        private EventType DeterminedEvent(string notificationMessage)
        {
            Console.WriteLine($"--> Determining Event {notificationMessage}");

            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);

            switch (eventType.Event)
            {
                case "Order_Published":
                    Console.WriteLine("Order Published Event Detected");
                    return EventType.OrderPublished;
                default:
                    Console.WriteLine($"--> Could not determine the event type {eventType.Event}");
                    return EventType.Undertermened;

            }

        }
        private void addOrder(string orderPublishedMessage)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IProductRepo>();

                var orderPublishedDto = JsonSerializer.Deserialize<OrderPublishedDto>(orderPublishedMessage);
                try
                {
                    var order = _mapper.Map<Order>(orderPublishedDto);
                    Console.WriteLine($"--> Updating the inventory now {JsonSerializer.Serialize(order)}");
                    repo.UpdateQuantity(order.Quantity, order.ProductId);
                    repo.SaveChanges();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not update inventory of product {ex.Message}");
                }
            }
        }
    }

    enum EventType
    {
        OrderPublished,
        Undertermened
    }
}