using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EAISolutionFrontEnd.SharedKernel.Interfaces;
using EAISolutionFrontEnd.Core;

namespace EAISolutionFrontEnd.Core.Interfaces
{
    public interface IRequestRepository : IAsyncRepository<Request>
    {
        bool IsPendingRequest(int UserId);
        Task<List<Request>> GetByUserIdAsync(int UserId);
        Task<List<Request>> GetAllActiveByUserIdAsync(int UserId);
        Task UpdateByUserIdAsync(Request request);
    }
}
