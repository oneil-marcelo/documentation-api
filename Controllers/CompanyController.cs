using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentationApi.Models;
using DocumentationApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DocumentationApi.Controllers
{
   
    [Route("v1/[controller]")]
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _repository;

        public CompanyController(ICompanyRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Obtém e retorna uma lista com todas as companhias.
        /// </summary>
        /// <response code="200">Obtém e retorna uma lista com todas as companhias.</response>
        /// <response code="404">Se lista for nula, retorna mensagem de companhias inexistentes.</response> 
        [HttpGet]
        [Produces("application/json", Type = typeof(List<Company>))]
        public async Task<IActionResult> GetCompaniesAsync()
        {
            var companies = await _repository.getCompaniesAsync(); 
            
            if(companies != null)
                return Ok(companies);
            else
                return NotFound("Nenhuma companhia cadastrada.");
        }

        /// <summary>
        /// Obtém e retorna uma companhia filtrada pelo nome.
        /// </summary>
        /// <param name="name">O parametro "name" é uma string utilizada para filtrar uma campanhia pelo nome.</param> 
        /// <response code="200">Obtém e retorna uma companhia filtrada pelo nome.</response>
        /// <response code="404">Se item for nulo, retorna mensagem de companhia inexistente.</response> 
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