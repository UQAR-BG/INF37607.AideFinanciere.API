using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EAISolutionFrontEnd.Core;
using EAISolutionFrontEnd.Core.Interfaces;

namespace EAISolutionFrontEnd.Infrastructure
{
    public class RequestRepository : EfRepository<Request>, IRequestRepository
    {
        public RequestRepository(EAISolutionFrontEndContext eAISolutionFrontEndContext) : base(eAISolutionFrontEndContext)
        {
        }
        public Task<Request> GetByUserIdAsync(int UserId)
        {
            return _EAISolutionFrontEndContext.Requests
              .FirstOrDefaultAsync(u => u.UserId == UserId);
        }

        public async Task UpdateByUserIdAsync(Request updatedRequest)
        {
            var existingRequest = await _EAISolutionFrontEndContext.Requests
                .FirstOrDefaultAsync(r => r.UserId == updatedRequest.UserId);

            if (existingRequest == null)
            {
                await _EAISolutionFrontEndContext.Requests.AddAsync(updatedRequest);
                return;
            }
            updatedRequest.Id = existingRequest.Id;
            
            _EAISolutionFrontEndContext.Requests.Entry(existingRequest).CurrentValues.SetValues(updatedRequest);

            await _EAISolutionFrontEndContext.SaveChangesAsync();
        }

    }
}
