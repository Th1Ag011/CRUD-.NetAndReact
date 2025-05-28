using System;

namespace VestibularApp.Application.Dtos.Request
{
    public class InscricaoRequestDto
    {
        public Guid CandidatoId { get; set; }
        public int NumeroInscricao { get; set; }
        public Guid ProcessoSeletivoId { get; set; }
        public Guid CursoId { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
    }
}
