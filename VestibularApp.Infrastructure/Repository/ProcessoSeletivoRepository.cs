using VestibularApp.Domain.Entities;
using VestibularApp.Domain.Interfaces;
using VestibularApp.Infrastructure.Data;

namespace VestibularApp.Infrastructure.Repository
{
    public class ProcessoSeletivoRepository : GenericRepository<ProcessoSeletivo>, IProcessoSeletivoRepository
    {
        public ProcessoSeletivoRepository(VestibularContext context) 
            : base(context)
        {
        }
    }
}
