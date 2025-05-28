using System;

namespace VestibularApp.Application.Dtos.Request
{
    public class ProcessoSeletivoRequestDto
    {
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
    }
}
