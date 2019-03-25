using System;

namespace DocumentationApi.Models
{
    /// <summary>
    /// Jogo.
    /// </summary>
    public class Game : Entity
    {
        /// <summary>
        /// Obtém ou define o Id da companhia.
        /// Chave estrangeira no relacionamento de entidade.
        /// </summary>
        /// <value>O Id da Companhia</value>
        public string CompanyId { get; set; }

        /// <summary>
        /// Obtém ou define o objeto companhia.
        /// Objeto que permite relacionamento quando do uso de object-relational mapper (O/RM).
        /// </summary>
        /// <value>A companhia</value>
        public Company Company { get; set; }
    }
}