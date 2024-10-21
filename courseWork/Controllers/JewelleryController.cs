using courseWork.Dto;
using courseWork.Services;
using Microsoft.AspNetCore.Mvc;

namespace courseWork.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JewelleryController : ControllerBase
    {
        private readonly IJewelleryService _jewelleryService;

        public JewelleryController(IJewelleryService jewelleryService)
        {
            _jewelleryService = jewelleryService;
        }

        [HttpGet]
        public ActionResult<List<JewelleryDto>> GetJewellery()
        {
            return Ok(_jewelleryService.GetJewellery());
        }

        [HttpGet ("{id}")]
        public ActionResult<JewelleryDto> GetOneJewellery(int id) 
        {
            var jewellery = _jewelleryService.GetOneJewellery(id);
            if (jewellery != null)
            {
                return Ok(jewellery);
            }
            return BadRequest();
        }

        [HttpPost]
        public ActionResult<JewelleryDto> AddJewellery(JewelleryDto jewellery)
        {
            return Ok(_jewelleryService.AddJewellery(jewellery));
        }

        [HttpDelete]
        public ActionResult<bool> RemoveJewellery(int id)
        {
            return Ok(_jewelleryService?.RemoveJewellery(id));
        }

        [HttpPut]
        public ActionResult<JewelleryDto> UpdateJewellery(JewelleryDto jewellery)
        {
            try
            {
                _jewelleryService.UpdateJewellery(jewellery);

                return Ok(jewellery);
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
