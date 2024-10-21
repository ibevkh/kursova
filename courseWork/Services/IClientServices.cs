using courseWork.Dto;

namespace courseWork.Services
{
    public interface IClientServices
    {
        public List<ClientDto> GetClients();
        public ClientDto AddClient(ClientDto client);
    }
}
