using System.Threading.Tasks;
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

        [HttpGet]
        public async Task<IActionResult> GetCompaniesAsync()
        {
            var companies = await _repository.getCompaniesAsync();
            return Ok(companies);
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> GetCompanyByNameAsync(string name)
        {
            var company = await _repository.getCompanyByNameAsync(name);
            return Ok(company);
        }

    }
}