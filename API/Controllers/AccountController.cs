using Core.Module.Accounts.Dtos;
using Core.Module.Accounts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("ListAccount")]
        public IActionResult ListAccount()
        {
            return(Ok(_accountService.GetAccountList()));
        }

        [HttpPost]
        [Route("CreateAccount")]
        public IActionResult CreateAccount([FromBody] AccountSaveDto dto)
        {
            _accountService.SaveAccount(dto);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateAccount")]
        public IActionResult UpdateAccount([FromBody] AccountSaveDto dto)
        {
            _accountService.UpdateAccount(dto);
            return Ok();
        }

        [HttpPatch]
        [Route("DesactiveAccount/{numberAccount}")]
        public IActionResult DesactiveAccount(string numberAccount)
        {
            _accountService.DesactiveAccount(numberAccount);
            return Ok();
        }
    }
}
