using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VestibularApp.Domain.Entities
{
    public class Inscricao
    {
        public Guid Id { get; set; }
        public string NumeroInscricao { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }

        public Guid CandidatoId { get; set; }
        public Candidato Candidato { get; set; }

        public Guid ProcessoSeletivoId { get; set; }
        public ProcessoSeletivo ProcessoSeletivo { get; set; }

        public Guid CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}
