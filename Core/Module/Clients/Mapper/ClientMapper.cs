using AutoMapper;
using Core.Module.Clients.Dtos;
using DB.Entities;

namespace Core.Module.Clients.Mapper
{
    public class ClientMapper : Profile
    {
        public ClientMapper() 
        {
            CreateMap<ClientDto, Client>();
            CreateMap<Client, ClientDto>();

            CreateMap<ClientSaveDto, Client>();
            CreateMap<Client, ClientSaveDto>();
        }
    }
}
