using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentationApi.Models;

namespace DocumentationApi.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> getCompaniesAsync();
        Task<Company> getCompanyByNameAsync(string name);
    }
}