using Core.Module.Accounts.Dtos;
using Core.Module.Accounts.Interfaces;
using DB;
using DB.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.Exceptions;
using Shared.Validate.Interfaces;

namespace Core.Module.Accounts.Service
{
    public class AccountService : IAccountService
    {
        private readonly BancoDbContext _context;
        private readonly IDtoService _dtoService;

        public AccountService(BancoDbContext context, IDtoService dtoService)
        {
            _context = context;
            _dtoService = dtoService;
        }

        public IList<AccountDto> GetAccountList()
        {
            var list = _context.Accounts.Include(x => x.Client).ToList();
            return _dtoService.Map<IList<AccountDto>>(list);
        }

        public void SaveAccount(AccountSaveDto dto)
        {
            _dtoService.Validate(dto);

            var currentAccount = _context.Accounts.Find(dto.NumberAccount);
            if (currentAccount != null)
            {
                throw new ApiException("El número de cuenta ya se encuentra registrado");
            }

            var currentClient = _context.Clients.FirstOrDefault(x => x.IdentityDocument == dto.IdentityDocument);
            if (currentClient == null)
            {
                throw new ApiException("El cliente no existe");
            }

            var account = _dtoService.Map<Account>(dto);
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        public void UpdateAccount(AccountSaveDto dto)
        {
            _dtoService.Validate(dto);

            var currentAccount = _context.Accounts.Find(dto.NumberAccount);
            if (currentAccount == null)
            {
                throw new ApiException("El número de cuenta no existe o no se encuentra registrado en el sistema");
            }

            var currentClient = _context.Clients.FirstOrDefault(x => x.IdentityDocument == dto.IdentityDocument);
            if (currentClient == null)
            {
                throw new ApiException("El cliente no existe");
            }

            _dtoService.Map(dto, currentAccount);
            _context.SaveChanges();
        }

        public void DesactiveAccount(string numberAccount)
        {
            var account = _context.Accounts.Find(numberAccount);
            if (account == null)
            {
                throw new ApiException("El número de cuenta no existe o no se encuentra registrado en el sistema");
            }

            account.Status = false;
            _context.Accounts.Update(account);
            _context.SaveChanges();
        }
    }
}
