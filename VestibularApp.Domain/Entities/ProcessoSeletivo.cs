using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VestibularApp.Domain.Entities
{
    public class ProcessoSeletivo
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }

        public IEnumerable<Inscricao> Inscricoes { get; set; }
    }
}
