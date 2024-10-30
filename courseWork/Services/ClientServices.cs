//using AutoMapper;
//using courseWork.Dto;
//using courseWork.Entity;
//using Microsoft.AspNetCore.Mvc;

//namespace courseWork.Services
//{
//    public class ClientServices : IClientServices
//    {
//        private readonly IMapper _mapper;
//        private readonly JewelleryContext _db;
//        public ClientServices(IMapper mapper, JewelleryContext db)
//        {
//            _mapper = mapper;
//            _db = db;
//        }

//        public List<CustomerDto> GetClients()
//        {
//            return _mapper.Map<List<CustomerDto>>(_db.Customers.ToList());
//        }

//        public CustomerDto AddClient(CustomerDto client)
//        {
//            var newClient = _db.Customers.Add(_mapper.Map<Customer>(client));
//            _db.SaveChanges();
//            return _mapper.Map<CustomerDto>(client);
//        }

//    }
//}
