using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentationApi.Models;

namespace DocumentationApi.Repositories
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetGamesAsync();
        Task<IEnumerable<Game>> GetGamesByCompany(string company);
        Task<Game> GetGameByIdAsync(string id);
    }
}