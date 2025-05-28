using System;


namespace VestibularApp.Application.Dtos.Reponse
{
    public class CursoResponseDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int VagasDisponiveis { get; set; }
    }
}
