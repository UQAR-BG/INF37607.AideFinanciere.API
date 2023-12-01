using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using INF37607.AideFinanciere.Core.Enums;

namespace EAISolutionFrontEnd.Core.Interfaces
{
    public interface IFinancialAideService
    {
        Task<List<FinancialAide>> GetFinancialAides(int userId, FinancialAideStatus status);
        Task<FinancialAide> AddFinancialAide(FinancialAide financialAide);
        Task UpdateFinancialAide(FinancialAide financialAide);
        Task DeleteFinancialAide(FinancialAide financialAide);
       

    }
}
