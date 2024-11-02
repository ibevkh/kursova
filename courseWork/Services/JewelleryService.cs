using AutoMapper;
using courseWork.Dto;
using courseWork.Entity;
using courseWork.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace courseWork.Services
{
    public class JewelleryService : IJewelleryService
    {
        private readonly IMapper _mapper;
        private readonly JewelleryContext _db;

        public JewelleryService(IMapper mapper, JewelleryContext db)
        {
            _mapper = mapper;
            _db = db;
        }
        public async Task<List<JewelleryDto>> GetJewelleryAsync()
        {
            var jewelleries = await _db.Jewelleries.ToListAsync();
            return _mapper.Map<List<JewelleryDto>>(jewelleries);
        }

        public async Task<JewelleryDto> GetOneJewelleryAsync(int id)
        {
            var jewellery = await _db.Jewelleries.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<JewelleryDto>(jewellery);
        }

        public async Task<JewelleryDto> AddJewelleryAsync(JewelleryDto jewellery)
        {
            var newJewellery = (await _db.Jewelleries.AddAsync(_mapper.Map<Jewellery>(jewellery))).Entity;
            await _db.SaveChangesAsync();

            return _mapper.Map<JewelleryDto>(newJewellery);
        }

        public async Task<bool> RemoveJewelleryAsync(int id)
        {
            var removeJewellery = await _db.Jewelleries.FirstOrDefaultAsync(j => j.Id == id);
            if (removeJewellery != null)
            {
                _db.Jewelleries.Remove(removeJewellery);
                await _db.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<JewelleryDto> UpdateJewelleryAsync(JewelleryDto jewellery)
        {
            var jewelleryToUpdate = _mapper.Map<Jewellery>(jewellery);
            _db.Jewelleries.Update(jewelleryToUpdate);
            await _db.SaveChangesAsync();
            return _mapper.Map<JewelleryDto>(jewelleryToUpdate);
        }
    }
}
