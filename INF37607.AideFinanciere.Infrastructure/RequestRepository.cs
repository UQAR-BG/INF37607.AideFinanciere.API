using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EAISolutionFrontEnd.Core;
using EAISolutionFrontEnd.Core.Interfaces;
using INF37607.AideFinanciere.Core.Enums;

namespace EAISolutionFrontEnd.Infrastructure
{
    public class RequestRepository : EfRepository<Request>, IRequestRepository
    {
        public RequestRepository(EAISolutionFrontEndContext eAISolutionFrontEndContext) : base(eAISolutionFrontEndContext)
        {
        }

        public bool IsPendingRequest(int UserId)
        {
            return _EAISolutionFrontEndContext.Requests
                .Any(r => r.Status == FinancialAideStatus.Pending && r.UserId == UserId);
        }

        public async Task<List<Request>> GetByUserIdAsync(int UserId)
        {
            return await _EAISolutionFrontEndContext.Requests
              .Where(r => r.UserId == UserId)
              .ToListAsync();
        }
        
        public async Task<List<Request>> GetAllActiveByUserIdAsync(int UserId)
        {
            return await _EAISolutionFrontEndContext.Requests
                .Where(r => r.Status == FinancialAideStatus.Pending && r.UserId == UserId)
                .ToListAsync();
        }

        public async Task UpdateByUserIdAsync(Request updatedRequest)
        {
            var existingRequest = (await GetAllActiveByUserIdAsync(updatedRequest.UserId)).FirstOrDefault();

            if (existingRequest == null)
                return;
            
            updatedRequest.Id = existingRequest.Id;

            if (updatedRequest.FinancialAid != null)
            {
                await _EAISolutionFrontEndContext.FinancialAide.AddAsync(updatedRequest.FinancialAid);
                await _EAISolutionFrontEndContext.SaveChangesAsync();

                updatedRequest.FinancialAidId = updatedRequest.FinancialAid.Id;
            }
            
            _EAISolutionFrontEndContext.Requests.Entry(existingRequest).CurrentValues.SetValues(updatedRequest);

            await _EAISolutionFrontEndContext.SaveChangesAsync();
        }

    }
}
