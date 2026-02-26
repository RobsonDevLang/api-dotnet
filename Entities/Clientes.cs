using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace fundamentosApi.Entities
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool AceitaComunicado { get; set; }
        public DateTime DataCadastro { get; set; }
        // Ignora a propriedade Contatos na serialização JSON
        [JsonIgnore]
        public ICollection<Contatos> Contatos { get; set; } = new List<Contatos>();
    }
}