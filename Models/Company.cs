using System.Collections.Generic;

namespace DocumentationApi.Models
{
    /// <summary>
    /// Company.
    /// </summary>
    public class Company : Entity
    {
        /// <summary>
        /// Obtém ou define lista de jogos.
        /// Define o relacionamento 1 para n quando usado um object-relational mapper (O/RM).  
        /// </summary>
        /// <value>A coleção de jogos.</value>
        public IEnumerable<Game> Games { get; set; }
    }
}