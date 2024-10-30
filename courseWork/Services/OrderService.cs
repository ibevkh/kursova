using AutoMapper;
using courseWork.Dto;
using courseWork.Entity;
using courseWork.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace courseWork.Services
{
    public class OrderService: IOrderService
    {
        private readonly IMapper _mapper;
        private readonly JewelleryContext _db;

        public OrderService(IMapper mapper, JewelleryContext db)
        {
            _mapper = mapper;
            _db = db;
        }
        public List<OrderDto> GetOrdersAsync()
        {
            return _mapper.Map<List<OrderDto>>( _db.Orders.ToList());
        }

        public OrderDto GetOrderByIdAsync(int id)
        {
            //return _mapper.Map<OrderDto>(_db.Orders.FirstOrDefault(x => x.Id == id));
            var order = _db.Orders
                .Include(i => i.Customer)
                .Include(i => i.OrderJewelleries)
                    .ThenInclude(i => i.Jewellery)
                .FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                return null;
            }

            return new OrderDto
            {
                Id = order.Id,
                Customer = new CustomerDto
                {
                    Id = order.Customer.Id,
                    Address = order.Customer.Address,
                    City = order.Customer.City,
                    Email = order.Customer.Email,
                    FirstName = order.Customer.FirstName,
                    LastName = order.Customer.LastName,
                    PhoneNumber = order.Customer.PhoneNumber,
                },
                Jewelleries = order.OrderJewelleries.Select(x => new OrderJewelleryItemDto
                {
                    Id = x.Jewellery.Id,
                    Gemstones = x.Jewellery.Gemstones,
                    Material = x.Jewellery.Material,
                    Name = x.Jewellery.Name,
                    Price = x.Jewellery.Price,
                    Size = x.Jewellery.Size,
                    Type = x.Jewellery.Type
                })
            };
        }

        public OrderDto AddOrderAsync(OrderDto order)
        {
            //var tran = _db.Database.BeginTransaction();
            
            // insert customer
            try
            {
                var customer = _mapper.Map<Customer>(order.Customer);
                var newCustomer = _db.Customers.Add(customer).Entity;

                _db.SaveChanges();

                var newOrder = _db.Orders.Add(new Order
                {
                    CustomerId = newCustomer.Id,
                    
                }).Entity;

                _db.SaveChanges();


                var jewelleries = _mapper.Map<IEnumerable<Jewellery>>(order.Jewelleries);

                var orderJewelleries = order.Jewelleries.Select(x => new OrderJewelleries
                {
                    Quantity = x.Quantity,
                    JewelleryId = x.Id,
                    OrderId = newOrder.Id,
                });

                foreach (var item in orderJewelleries)
                {
                    _db.OderJewelleries.Add(item);
                }

                _db.SaveChanges();

                //tran.Commit();

                return GetOrderByIdAsync(newOrder.Id);
            }
            catch (Exception ex) 
            {
                //tran.Rollback();
                throw;
            }
        }
    }
}
