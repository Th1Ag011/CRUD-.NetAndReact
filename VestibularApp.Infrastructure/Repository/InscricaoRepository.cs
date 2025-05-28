using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VestibularApp.Domain.Entities;
using VestibularApp.Domain.Interfaces;
using VestibularApp.Infrastructure.Data;

namespace VestibularApp.Infrastructure.Repository
{
    public class InscricaoRepository : GenericRepository<Inscricao> , IInscricaoRepository
    {
        public InscricaoRepository(VestibularContext context) 
            : base(context) 
        {
        }

        public async Task <IEnumerable<Inscricao>> GetByCandidatoCpfAsync(string cpf)
        {
            return await _dbContext
                .AsNoTracking()
                .Include(i => i.Candidato)
                .Include(i => i.ProcessoSeletivo)
                .Where(i => i.Candidato.CPF == cpf)
                .ToListAsync();
        }

        public async Task<IEnumerable<Inscricao>> GetByCursoIdAsync(Guid id)
        {
            return await _dbContext
                .AsNoTracking()
                .Include(i => i.Curso)
                .Where(i => i.CursoId == id)
                .ToListAsync();
        }


    }
}
