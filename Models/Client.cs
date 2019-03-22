using System.ComponentModel.DataAnnotations;

namespace DocumentationApi.Models
{
#pragma warning disable CS1591

    public class Client
    {
        /// <Sumary>
        /// Obtém ou define o nome
        /// </Sumary>
        /// <Value> O Nome</Value>
        [Required]
        public string Name { get; set; }

    }
}