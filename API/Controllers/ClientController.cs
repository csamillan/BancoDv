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
        [Route("ListClient")]
        public IActionResult ListClient()
        {
            return Ok(_clientService.GetClientList());
        }

        [HttpGet]
        [Route("GetClientByIdentity/{identity}")]
        public IActionResult GetClientByIdentity(string identity)
        {
            return Ok(_clientService.GetClientByIdentification(identity));
        }

        [HttpPost]
        [Route("CreateClient")]
        public IActionResult CreateClient([FromBody] ClientSaveDto dto)
        {
            _clientService.SaveClient(dto);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateClient")]
        public IActionResult UpdateClient([FromBody] ClientSaveDto dto)
        {
            _clientService.updateClient(dto);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteClient/{identity}")]
        public IActionResult DeleteClient(string identity)
        {
            _clientService.DeleteClient(identity);
            return Ok();
        }
    }
}
