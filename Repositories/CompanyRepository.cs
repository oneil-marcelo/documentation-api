using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentationApi.Models;

namespace DocumentationApi.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        // public CategoryRepository()
        // {   
           List<Company> companies = new List<Company> {
               
               new Company {
                   Name = "Capcom"
               },
               new Company {
                   Name = "EA-Sports"
               },
               new Company {
                   Name = "Konami"
               }
           }; 
        // }
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