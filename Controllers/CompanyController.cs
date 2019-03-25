using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentationApi.Models;
using DocumentationApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DocumentationApi.Controllers
{
   
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _repository;

        public CompanyController(ICompanyRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retorna lista com todas as Companhias.
        /// </summary>
        /// <response code="200">Retorna lista com todas as Companhias.</response>
        /// <response code="404">Retorna mensagem de companhias inexistentes.</response> 
        [HttpGet]
        [Produces("application/json", Type = typeof(List<Company>))]
        public async Task<IActionResult> GetCompaniesAsync()
        {
            var companies = await _repository.getCompaniesAsync(); 
            companies = null;
            if(companies != null)
                return Ok(companies);
            else
                return NotFound("Nenhuma companhia cadastrada.");
        }

        /// <summary>
        /// Retorna uma companhia filtra pelo nome.
        /// </summary>
        /// <response code="200">Retorna uma companhia.</response>
        /// <response code="404">Retorna mensagem se a companhia é inexistente.</response> 
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Company))]
        [ProducesResponseType(404)]
        [Route("{name}")]
        public async Task<IActionResult> GetCompanyByNameAsync(string name)
        {
            var company = await _repository.getCompanyByNameAsync(name);

            if(company != null)
                return Ok(company);
            else
                return NotFound($"Não foi localizada nenhuma companhia com o nome {name}");
        }

    }
}