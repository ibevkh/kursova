using AutoMapper;
using courseWork.Dto;
using courseWork.Entity;
using courseWork.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace courseWork.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly JewelleryContext _db;

        public OrderService(IMapper mapper, JewelleryContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<List<OrderDto>> GetOrdersAsync()
        {
            var orders = await _db.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderJewelleries)
                .ThenInclude(oj => oj.Jewellery)
                .ToListAsync();
            return _mapper.Map<List<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetOrderByIdAsync(int id)
        {
            var order = await _db.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderJewelleries)
                .ThenInclude(oj => oj.Jewellery)
                .FirstOrDefaultAsync(o => o.Id == id);

            return order == null ? null : _mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto> AddOrderAsync(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);

            var newOrder = (await _db.Orders.AddAsync(order)).Entity;
            await _db.SaveChangesAsync();

            return await GetOrderByIdAsync(newOrder.Id);
        }
    }
}