using VestibularApp.Domain.Entities;
using VestibularApp.Domain.Interfaces;
using VestibularApp.Infrastructure.Data;

namespace VestibularApp.Infrastructure.Repository
{
    public class CandidatoRepository : GenericRepository<Candidato>, ICandidatoRepository
    {
        public CandidatoRepository(VestibularContext context) 
            : base(context)
        {
        }
    }
}
