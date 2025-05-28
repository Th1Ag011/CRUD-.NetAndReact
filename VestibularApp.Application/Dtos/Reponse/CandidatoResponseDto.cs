using System;


namespace VestibularApp.Application.Dtos.Reponse
{
    public class CandidatoResponseDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
    }
}
