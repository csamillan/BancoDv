using Core.Module.Clients.Dtos;
using Core.Module.Clients.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult ListClient()
        {
            return Ok(_clientService.GetClientList());
        }

        [HttpPost]
        public IActionResult CreateClient([FromBody] ClientSaveDto dto)
        {
            _clientService.SaveClient(dto);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateClient([FromBody] ClientSaveDto dto)
        {
            _clientService.updateClient(dto);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteClient(string identity)
        {
            _clientService.DeleteClient(identity);
            return Ok();
        }
    }
}
