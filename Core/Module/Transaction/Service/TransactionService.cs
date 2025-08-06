using Core.Module.Transaction.Dtos;
using Core.Module.Transaction.Interfaces;
using DB;
using DB.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.Enum;
using Shared.Exceptions;
using Shared.Report.Interfaces;
using Shared.Validate.Interfaces;
using Shared.Vistas;

namespace Core.Module.Transaction.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly BancoDbContext _context;
        private readonly IDtoService _dtoService;
        private readonly IGenerateReport _generateReport;

        public TransactionService(BancoDbContext context, IDtoService dtoService, IGenerateReport generateReport)
        {
            _context = context;
            _dtoService = dtoService;
            _generateReport = generateReport;
        }
        
        public IList<TransactionDto> GetTransaccionList(string accountNumber)
        {
            var list = _context.Transactions
                                        .Include(x => x.Account)
                                        .Where(x => x.AccountNumberAccount == accountNumber)
                                        .ToList();

            return _dtoService.Map<IList<TransactionDto>>(list);
        }

        public ResponseReport GetReportTransactionsForDates(FilterReport filter)
        {
            string base64Report = "";
            var list = _context.Transactions
                                    .Where(t => t.AccountNumberAccount == filter.AccountNumber &&
                                                t.Date >= filter.StartDate &&
                                                t.Date <= filter.EndDate)
                                    .Select(t => new TransactionReport
                                    {
                                        Date = t.Date,
                                        Name = t.Account != null && t.Account.Client != null ? t.Account.Client.Name : "",
                                        AccountNumber = t.Account != null ? t.Account.NumberAccount : "",
                                        Type = t.Account != null ? t.Account.AccountType.ToString() : "N/A",
                                        InitialSald = t.Sald,
                                        Status = t.Account != null ? t.Account.Status : false,
                                        Transactions = t.Value,
                                        CurrectSald = t.Account != null
                                            ? (t.TypeMovement == TypeTransaccion.Credito ? (t.Sald) + t.Value : (t.Sald) - t.Value)
                                            : 0
                                    })
                                    .ToList();

            if(list.Count > 0) base64Report = _generateReport.GenerateTransactionReportPdfBase64(list);

            ResponseReport responseReport = new ResponseReport
            {
                Transactions = list,
                Base64Report = base64Report
            };

            return responseReport;
        }

        public void SaveTransaction(TransactionSaveDto dto)
        {
            _dtoService.Validate(dto);

            var transaction = validateSaveTransaction(dto);
            var account = _context.Accounts.FirstOrDefault(a => a.NumberAccount == dto.AccountNumberAccount);
            account.InitialBalance = dto.TypeMovement == TypeTransaccion.Debito ? (account.InitialBalance - dto.Value) : (account.InitialBalance + dto.Value);

            _context.Transactions.Add(transaction);
            _context.Accounts.Update(account);
            _context.SaveChanges();
        }

        private Transactions validateSaveTransaction(TransactionSaveDto dto)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.NumberAccount == dto.AccountNumberAccount);
            if (account == null)
            {
                throw new ApiException("La cuenta ingresa no existe");
            }

            if (dto.TypeMovement == TypeTransaccion.Debito)
            {
                if (account.InitialBalance - dto.Value < 0)
                {
                    throw new ApiException("Saldo insuficiente para realizar la transacción");
                }

                decimal total = _context.Transactions
                                    .Where(x => x.TypeMovement == TypeTransaccion.Debito && x.Date.Date == dto.Date.Date && x.AccountNumberAccount == dto.AccountNumberAccount)
                                    .Sum(x => x.Value);

                if (total + dto.Value >= 1000)
                {
                    throw new ApiException("Cupo Diario Excedido");
                }
            }

            var transaction = _dtoService.Map<Transactions>(dto);
            transaction.Sald = account.InitialBalance ?? 0;

            return transaction;
        }

    }
}
