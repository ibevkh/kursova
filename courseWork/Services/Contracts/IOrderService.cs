using courseWork.Dto;

namespace courseWork.Services.Contracts
{
    public interface IOrderService
    {
        public List<OrderDto> GetOrdersAsync();
        public OrderDto GetOrderByIdAsync(int id);
        public OrderDto AddOrderAsync(OrderDto jewellery);
    }
}
