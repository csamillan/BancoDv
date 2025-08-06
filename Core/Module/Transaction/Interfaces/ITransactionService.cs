using Core.Module.Transaction.Dtos;
using Shared.Vistas;

namespace Core.Module.Transaction.Interfaces
{
    public interface ITransactionService
    {
        IList<TransactionDto> GetTransaccionList(string accountNumber);
        void SaveTransaction(TransactionSaveDto dto);
        ResponseReport GetReportTransactionsForDates(FilterReport filter);
    }
}
