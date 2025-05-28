using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VestibularApp.Domain.Entities;

namespace VestibularApp.Domain.Interfaces
{
    public interface IInscricaoRepository : IGenericRepository<Inscricao>
    {
        Task <IEnumerable<Inscricao>> GetByCandidatoCpfAsync(string cpf);
        Task <IEnumerable<Inscricao>> GetByCursoIdAsync(Guid id);
    }
}
