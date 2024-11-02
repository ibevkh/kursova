using courseWork.Dto;
using courseWork.Entity;
using courseWork.Services;
using courseWork.Services.Contracts;
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
        public async Task<ActionResult<List<JewelleryDto>>> GetJewellery()
        {
            return Ok(await _jewelleryService.GetJewelleryAsync());
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<JewelleryDto>> GetOneJewellery(int id) 
        {
            var jewellery = await _jewelleryService.GetOneJewelleryAsync(id);
            if (jewellery != null)
            {
                return Ok(jewellery);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<JewelleryDto>> AddJewellery(JewelleryDto jewellery)
        {
            return Ok( await _jewelleryService.AddJewelleryAsync(jewellery));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> RemoveJewellery(int id)
        {
            return Ok(await _jewelleryService?.RemoveJewelleryAsync(id));
        }

        [HttpPut]
        public async Task<ActionResult<JewelleryDto>> UpdateJewellery(JewelleryDto jewellery)
        {
            try
            {
                return Ok(await _jewelleryService.UpdateJewelleryAsync(jewellery));
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
