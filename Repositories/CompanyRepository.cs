using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentationApi.Models;
using Microsoft.Extensions.Configuration;

namespace DocumentationApi.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly List<Company> companies;
        private readonly IConfiguration _configuration;
        public CompanyRepository(IConfiguration configuration)
         {   
           
           _configuration = configuration;
           
           companies = new List<Company> {
               
               new Company {
                   Name = "Capcom",
                   Image = $"{_configuration["baseUrlActive"]}images/capcom.png"
               },
               new Company {
                   Name = "EA-Sports",
                   Image = $"{_configuration["baseUrlActive"]}images/ea-sports.png"
               },
               new Company {
                   Name = "Konami",
                   Image = $"{_configuration["baseUrlActive"]}images/konami.png"
               }
           }; 
        }
        public async Task<IEnumerable<Company>> getCompaniesAsync()
        {
           return await Task.FromResult(companies);
        }

        public async Task<Company> getCompanyByNameAsync(string name)
        {
            return await Task.FromResult(
                companies.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault()
            );
        }
    }
}