using System;

namespace VestibularApp.Application.Dtos.Reponse
{
    public class ProcessoSeletivoResponseDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
    }
}
