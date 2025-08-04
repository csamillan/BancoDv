using Core.Module.Clients.Dtos;

namespace Core.Module.Clients.Interfaces
{
    public interface IClientService
    {
        IList<ClientDto> GetClientList();
        void SaveClient(ClientSaveDto dto);
        void updateClient(ClientSaveDto dto);
        void DeleteClient(string identity);
    }
}
