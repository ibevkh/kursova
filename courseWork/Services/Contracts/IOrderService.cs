using courseWork.Dto;

namespace courseWork.Services.Contracts
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetOrdersAsync();
        Task<OrderDto> GetOrderByIdAsync(int id);
        Task<OrderDto> AddOrderAsync(OrderDto jewellery);
    }
}
