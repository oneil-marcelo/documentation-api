using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentationApi.Models;
using DocumentationApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DocumentationApi.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private readonly IGameRepository _repository;

        public GameController(IGameRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retorna lista com todos os jogos.
        /// </summary>
        /// <response code="200">Retorna lista com todos os jogos.</response>
        /// <response code="404">Retorna mensagem de jogos inexistentes.</response>
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
        /// Retorna um jogo.
        /// </summary>
        /// <param name="id">Guid no formato de string.</param>
        /// <response code="200">Retorna um jogo.</response>
        /// <response code="404">Retorna mensagem jogo inexistente.</response>
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
        ///  Retorna todos os jogos da companhia especificada no parametro.
        /// </summary>
        /// <response code ="200">Retorna lista de jogos da companhia especificada.</response>
        /// <response code="404">Retorna mensagem companhia não possui jogos cadastrados.</response>
        /// <param name="company">String nome da companhia.</param>
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