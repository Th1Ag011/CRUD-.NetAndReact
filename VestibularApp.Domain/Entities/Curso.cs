using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VestibularApp.Domain.Entities
{
    public class Curso
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int VagasDisponiveis { get; set; }

        public IEnumerable<Inscricao> Inscricoes { get; set; }
    }
}
