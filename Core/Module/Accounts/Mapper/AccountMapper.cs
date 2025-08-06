using AutoMapper;
using Core.Module.Accounts.Dtos;
using DB.Entities;

namespace Core.Module.Accounts.Mapper
{
    public class AccountMapper : Profile
    {
        public AccountMapper() { 
        
            CreateMap<Account, AccountDto>();
            CreateMap<AccountDto, Account>();

            CreateMap<AccountSaveDto, Account>();
            CreateMap<Account, AccountSaveDto>();
        }

    }
}
