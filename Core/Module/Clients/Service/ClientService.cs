using Core.Module.Clients.Dtos;
using Core.Module.Clients.Interfaces;
using DB;
using DB.Entities;
using Shared.Exceptions;
using Shared.Validate.Interfaces;
using Shared.Vistas;

namespace Core.Module.Clients.Service
{
    public class ClientService : IClientService
    {
        private readonly BancoDbContext _context;
        private readonly IDtoService _dtoService;

        public ClientService(BancoDbContext context, IDtoService toService)
        {
            _context = context;
            _dtoService = toService;
        }

        public IList<ClientDto> GetClientList()
        {
            var list = _context.Clients.ToList();
            return _dtoService.Map<IList<ClientDto>>(list);
        }

        public ClientDto GetClientByIdentification(string identity)
        {
            var currentClient = _context.Clients.Find(identity);

            if (currentClient == null)
            {
                throw new ApiException("Cliente no encontrado");
            }

            return _dtoService.Map<ClientDto>(currentClient);
        }

        public void SaveClient(ClientSaveDto dto)
        {
            _dtoService.Validate(dto);

            var currentClient = _context.Clients.Find(dto.IdentityDocument);
            if (currentClient != null)
            {
                throw new ApiException("El cliente ya se encuentra registrado");
            }

            var client = _dtoService.Map<Client>(dto);

            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public void updateClient(ClientSaveDto dto)
        {
            _dtoService.Validate(dto);

            var currentClient = _context.Clients.Find(dto.IdentityDocument);
            if (currentClient == null)
            {
                throw new ApiException("El cliente no se encuentra registrado");
            }

            _dtoService.Map(dto, currentClient);
            _context.SaveChanges();
        }

        public void DeleteClient(string identity)
        {
            var client = _context.Clients.Find(identity);
            if (client == null)
            {
                throw new ApiException("El cliente no se encuentra registrado");
            }
            _context.Clients.Remove(client);
            _context.SaveChanges();
        }

    }
}
