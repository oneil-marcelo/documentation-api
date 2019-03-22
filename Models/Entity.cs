using System;

namespace DocumentationApi.Models
{
    public class Entity
    {
        public string Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}