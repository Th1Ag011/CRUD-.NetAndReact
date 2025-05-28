using VestibularApp.Domain.Entities;
using VestibularApp.Domain.Interfaces;
using VestibularApp.Infrastructure.Data;

namespace VestibularApp.Infrastructure.Repository
{
    public class CursoRepository : GenericRepository<Curso>, ICursoRepository
    {
        public CursoRepository(VestibularContext context) 
            : base(context)
        {
        }
    }
}
