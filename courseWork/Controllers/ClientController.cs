using courseWork.Dto;
using courseWork.Services;
using Microsoft.AspNetCore.Mvc;

//namespace courseWork.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class ClientController : ControllerBase
//    {
//        private readonly IClientServices _clientServices;

//        public ClientController(IClientServices clientServices)
//        {
//            _clientServices = clientServices;
//        }

//        [HttpGet]

//        public ActionResult<List<CustomerDto>> GetClients()
//        {
//            return Ok(_clientServices.GetClients());
//        }

//        [HttpPost]
//        public ActionResult<CustomerDto> AddClient(CustomerDto client)
//        {
//            return Ok(_clientServices.AddClient(client));
//        }
//    }
//}
