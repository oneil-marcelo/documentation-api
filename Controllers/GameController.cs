using System;
using System.Threading.Tasks;
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

        [HttpGet]
        public async Task<IActionResult> GetGamesAsync()
        {
            var games = await _repository.GetGamesAsync();
            return Ok(games);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetGameByIdAsync(string id)
        {
            var games = await _repository.GetGameByIdAsync(id);
            return Ok(games);
        }

        [HttpGet]
        [Route("company/{name}")]
        public async Task<IActionResult> GetGameByCompanyAsync(string name)
        {
            var games = await _repository.GetGamesByCompany(name);
            return Ok(games);
        }
    }
}