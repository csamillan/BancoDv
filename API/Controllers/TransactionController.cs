using Core.Module.Transaction.Dtos;
using Core.Module.Transaction.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Vistas;

namespace API.Controllers
{
    [ApiController]
    [Route("api/transaction")]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        [Route("ListTransactionByAccount/{AccountNumber}")]
        public IActionResult ListTransactionByAccount(string AccountNumber)
        {
            return Ok(_transactionService.GetTransaccionList(AccountNumber));
        }

        [HttpGet]
        [Route("GenerateReportAccountByDates")]
        public IActionResult GenerateReportAccountByDates([FromQuery] FilterReport filterReport)
        {
            return Ok(_transactionService.GetReportTransactionsForDates(filterReport));
        }

        [HttpPost]
        [Route("CreateTransaction")]
        public IActionResult CreateTransaction([FromBody] TransactionSaveDto dto)
        {
            _transactionService.SaveTransaction(dto);
            return Ok();
        }
    }
}
