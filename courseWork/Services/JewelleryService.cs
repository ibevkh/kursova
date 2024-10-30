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

        public List<JewelleryDto> GetJewellery()
        {
            return _mapper.Map<List<JewelleryDto>>(_db.Jewelleries.ToList());
        }
        public JewelleryDto GetOneJewellery(int id)
        {
            return _mapper.Map<JewelleryDto>(_db.Jewelleries.FirstOrDefault(x => x.Id == id));
        }
        public JewelleryDto AddJewellery(JewelleryDto jewellery)
        {
            var newJewellery = _db.Jewelleries.Add(_mapper.Map<Jewellery>(jewellery)).Entity;
            _db.SaveChanges();

            return _mapper.Map<JewelleryDto>(newJewellery);
        }
        public bool RemoveJewellery(int id)
        {
            var removeJewellery = _db.Jewelleries.FirstOrDefault(j => j.Id == id);
            if (removeJewellery != null)
            {
                _db.Remove(removeJewellery);
                _db.SaveChanges();

                return true;
            }
            return false; 
        }
        public void UpdateJewellery(JewelleryDto jewellery)
        {
            var jewelleryToUpdate = _mapper.Map<Jewellery>(jewellery);
            _db.Jewelleries.Update(jewelleryToUpdate);
            _db.SaveChanges();
        }
    }
}
