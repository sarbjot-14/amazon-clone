using OrdersService.Dto;

namespace OrdersService.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PublishNewOrder(OrderPublishedDto orderPublishedDto);

    }
}