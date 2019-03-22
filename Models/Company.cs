using System.Collections.Generic;

namespace DocumentationApi.Models
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public IEnumerable<Game> Games { get; set; }
    }
}