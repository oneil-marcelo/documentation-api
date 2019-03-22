using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentationApi.Models;
using DocumentationApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClientApi.Controllers
{
    #pragma warning disable CS1591
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }


        /// <summary>
        /// Retorna todos os clientes.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "name": "Nome do cliente"
        ///     }
        ///
        /// </remarks>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="400">If the item is null</response> 
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Route("v1/clients")]
        public async Task<IEnumerable<Client>> Get()
        {
            return await _clientRepository.GetClientAsync();
        }

        /// <param name="name"></param>
        [HttpGet]
        [Route("v1/clients/{name}")]
        public async Task<Client> Get(string name)
        {
            return await _clientRepository.GetClientByNameAsync(name);
        }
    }
}