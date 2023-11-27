using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

using EAISolutionFrontEnd.Core.Interfaces;
using EAISolutionFrontEnd.Core.Specifications;
using EAISolutionFrontEnd.SharedKernel.Interfaces;

namespace EAISolutionFrontEnd.Core.Services
{
    public class FinancialService : IFinancialAideService
    {
        private readonly IFinancialAideRepository _FinancialAideRepository;
   
        public FinancialService(IFinancialAideRepository financialAideRepository)
        {
            _FinancialAideRepository = financialAideRepository;
        }

        public async Task<FinancialAide> GetFinancialAide(int userId)
        {
            return await _FinancialAideRepository.GetByIdAsync(userId);
        }
        public async Task<List<FinancialAide>> GetFinancialAides(int userId)
        {
            return await _FinancialAideRepository.GetListByIdAsync(userId);
        }

        public async Task<FinancialAide> AddFinancialAide(FinancialAide request)
        {
            return await _FinancialAideRepository.AddAsync(request);
        }
        public async Task UpdateFinancialAide(FinancialAide request)
        {
            await _FinancialAideRepository.UpdateAsync(request);
        }
        public async Task DeleteFinancialAide(FinancialAide request)
        {
            await _FinancialAideRepository.DeleteAsync(request);
        }
     
    }

}
