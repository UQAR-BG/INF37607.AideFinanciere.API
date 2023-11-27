using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EAISolutionFrontEnd.Core.Interfaces
{
    public interface IFinancialAideService
    {
        Task<List<FinancialAide>> GetFinancialAides(int userId);
        Task<FinancialAide> AddFinancialAide(FinancialAide financialAide);
        Task UpdateFinancialAide(FinancialAide financialAide);
        Task DeleteFinancialAide(FinancialAide financialAide);
       

    }
}
