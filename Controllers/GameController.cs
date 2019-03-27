using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentationApi.Models;
using DocumentationApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DocumentationApi.Controllers
{
    [Route("v1/[controller]")]
    public class GameController : Controller
    {
        private readonly IGameRepository _repository;

        public GameController(IGameRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Obtém e retorna uma lista com todos os jogos.
        /// </summary>
        /// <response code="200">Obtém e retorna uma lista com todos os jogos.</response>
        /// <response code="404">Se a lista for nula, retorna mensagem de jogos inexistentes.</response>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Game>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetGamesAsync()
        {
            var games = await _repository.GetGamesAsync();
            
            if(games != null)
                return Ok(games);
            else   
                return NotFound("Nenhum jogo cadastrado");
        }

        /// <summary>
        /// Obtém e retorna um jogo filtrado pelo Id.
        /// </summary>
        /// <param name="id">O parametro "id" é um GUID convertido em string e utilizado para filtrar um jogo pelo Id.</param>
        /// <response code="200">Obtém e retorna um jogo filtrado pelo Id.</response>
        /// <response code="404">Se item for nulo, retorna mensagem de jogo inexistente.</response>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(200, Type = typeof(Game))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetGameByIdAsync(string id)
        {
            var game = await _repository.GetGameByIdAsync(id);

            if(game != null)
                return Ok(game);
            else
                return NotFound($"Não foi localizado nenhum jogo com o id {id}.");
        }

        /// <summary>
        ///  Obtém e retorna uma lista de jogos filtrados pelo nome da companhia.
        /// </summary>
        /// <param name="company">O parametro "company" é utilizado para filtrar uma lista de jogos pelo nome da companhia.</param>
        /// <response code="200">Obtém e retorna uma lista de jogos filtrados pelo nome da companhia.</response>
        /// <response code="404">Se a lista for nula, retorna mensagem que a companhia não possui jogos cadastrados.</response>
        [HttpGet]
        [Route("{company}")]
        [ProducesResponseType(200, Type=typeof(List<Game>))]
        public async Task<IActionResult> GetGameByCompanyAsync(string company)
        {
            var games = await _repository.GetGamesByCompany(company);
            
            if(games != null)
                return Ok(games);
            else
                return NotFound($"Nenhum jogo cadastrado na companhia {company}.");
        }
    }
}