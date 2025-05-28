

using System;

namespace VestibularApp.Application.Dtos.Reponse
{
    public class InscricaoResponseDto
    {
        public Guid Id { get; set; }
        public string NumeroInscricao { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
    }
}
