using System;

namespace DocumentationApi.Models
{
    /// <summary>
    /// Entidade.
    /// Classe base para as entidades da aplicação. 
    /// </summary> 
    public class Entity
    {
        /// <summary>
        /// Obtém ou define o Id.
        /// </summary> 
        /// <value>O Id.</value>
        public string Id { get; set; }

        /// <summary>
        /// Obtém ou define o nome.
        /// </summary>
        /// <value> O nome.</value>
        public string Name { get; set; }

        /// <summary>
        /// Obtém ou define a imagem.
        /// </summary>
        /// <value>A imagem.</value>
        public string Image { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}