using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VestibularApp.Domain.Entities
{
    public class Candidato
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }

        public IEnumerable<Inscricao> Inscricoes { get; set; }
    }
}
