using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EAISolutionFrontEnd.Core;
using EAISolutionFrontEnd.Core.Interfaces;
using System.Linq;
using INF37607.AideFinanciere.Core.Enums;

namespace EAISolutionFrontEnd.Infrastructure
{
    public class FinancialAideRepository : EfRepository<FinancialAide>, IFinancialAideRepository
    {
        public FinancialAideRepository(EAISolutionFrontEndContext eAISolutionFrontEndContext) : base(eAISolutionFrontEndContext)
        {
        }

        public async Task<List<FinancialAide>> GetListByIdAsync(int userId, FinancialAideStatus status)
        {
            return await _EAISolutionFrontEndContext.Set<FinancialAide>().Where(entity => entity.UserId == userId).ToListAsync();
        }
    }
}
