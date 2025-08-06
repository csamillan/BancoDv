using Core.Module.Clients.Dtos;
using Shared.Vistas;

namespace Core.Module.Clients.Interfaces
{
    public interface IClientService
    {
        IList<ClientDto> GetClientList();
        ClientDto GetClientByIdentification(string identity);
        void SaveClient(ClientSaveDto dto);
        void updateClient(ClientSaveDto dto);
        void DeleteClient(string identity);
    }
}
