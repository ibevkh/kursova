using AutoMapper;
using courseWork.Dto;
using courseWork.Entity;
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
            return _mapper.Map<List<JewelleryDto>>(_db.JewelleryDB.ToList());
        }
        public JewelleryDto GetOneJewellery(int id)
        {
            return _mapper.Map<JewelleryDto>(_db.JewelleryDB.FirstOrDefault(x => x.Id == id));
        }
        public JewelleryDto AddJewellery(JewelleryDto jewellery)
        {
            var newJewellery = _db.JewelleryDB.Add(_mapper.Map<JewelleryEntity>(jewellery)).Entity;
            _db.SaveChanges();

            return _mapper.Map<JewelleryDto>(newJewellery);
        }
        public bool RemoveJewellery(int id)
        {
            var removeJewellery = _db.JewelleryDB.FirstOrDefault(j => j.Id == id);
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
            var jewelleryToUpdate = _mapper.Map<JewelleryEntity>(jewellery);
            _db.JewelleryDB.Update(jewelleryToUpdate);
            _db.SaveChanges();
        }
    }
}
