using System;

namespace DocumentationApi.Models
{
    public class Game : Entity
    {
        public string Name { get; set; }
        public string CompanyId { get; set; }
        public Company Company { get; set; }
    }
}