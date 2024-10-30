using courseWork.Dto;

namespace courseWork.Services.Contracts
{
    public interface IJewelleryService
    {
        public List<JewelleryDto> GetJewellery();
        public JewelleryDto GetOneJewellery(int id);
        public JewelleryDto AddJewellery(JewelleryDto jewellery);
        public bool RemoveJewellery(int id);
        public void UpdateJewellery(JewelleryDto jewellery);
    }
}
