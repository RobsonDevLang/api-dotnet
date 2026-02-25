using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fundamentosApi.Entities
{
    public class Contatos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
        public int ClienteId { get; set; }
        public Clientes Cliente { get; set; }
    }
}