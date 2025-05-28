using System;

namespace VestibularApp.Application.Dtos.Reponse
{
    public class InscricaoProcessoResponseDto
    {
        public Guid InscricaoId { get; set; }
        public string NumeroInscricao { get; set; }
        public string NomeCandidato { get; set; }
        public string StatusInscricao { get; set; }
        public string ProcessoSeletivoNome { get; set; }
        public DateTime DataInscricao { get; set; }
        public string Status { get; set; }
    }

}
