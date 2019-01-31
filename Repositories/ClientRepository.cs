using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentationApi.Models;

namespace DocumentationApi.Repositories
{
    #pragma warning disable CS1591
    public interface IClientRepository
    {
         Task<IEnumerable<Client>> GetClientAsync();
         Task<Client> GetClientByNameAsync(string name);
    }

    public class ClientRepository : IClientRepository
    {
     
        #region [clients]
        List<Client> clients = new List<Client>
        {   
            new Client{
                Name = "Primeiro Cliente"
            },
            
            new Client{
                Name = "Segundo Cliente"
            }, 
            
            new Client{
               Name = "Terceiro Cliente"
            }, 
            
            new Client{
                Name = "Quarto Cliente"
            }, 
            
            new Client{
                Name = "Quinto Cliente"
            }
        };
        #endregion
     
     
        public async Task<IEnumerable<Client>> GetClientAsync()
        {
            return await Task.FromResult(clients);     
        }

        public async Task<Client> GetClientByNameAsync(string name)
        {
            return await Task.FromResult(clients.Where(x => x.Name == name).FirstOrDefault());
        }

    }
}