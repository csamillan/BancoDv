using Core.Module.Accounts.Dtos;

namespace Core.Module.Accounts.Interfaces
{
    public interface IAccountService
    {
        IList<AccountDto> GetAccountList();
        void SaveAccount(AccountSaveDto dto);
        void UpdateAccount(AccountSaveDto dto);
        void DesactiveAccount(string numberAccount);
    }
}
