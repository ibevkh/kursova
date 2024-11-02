using courseWork.Dto;

namespace courseWork.Services.Contracts
{
    public interface IJewelleryService
    {
        Task<List<JewelleryDto>> GetJewelleryAsync();
        Task<JewelleryDto> GetOneJewelleryAsync(int id);
        Task<JewelleryDto> AddJewelleryAsync(JewelleryDto jewellery);
        Task<bool> RemoveJewelleryAsync(int id);
        Task<JewelleryDto> UpdateJewelleryAsync(JewelleryDto jewellery);
    }
}
