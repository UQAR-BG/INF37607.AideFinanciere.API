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
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _RequestRepository;
        
        public RequestService(IRequestRepository requestRepository)
        {
            _RequestRepository = requestRepository;
        }

        public bool IsPending(int userid)
        {
            return _RequestRepository.IsPendingRequest(userid);
        }

        public async Task<Request> GetRequest(int id)
        {
            return await _RequestRepository.GetByIdAsync(id);
        }

        public async Task<List<Request>> GetRequests(int userId)
        {
            return await _RequestRepository.GetByUserIdAsync(userId);
        }
        
        public async Task<List<Request>> GetAllActiveRequests(int userId)
        {
            return await _RequestRepository.GetAllActiveByUserIdAsync(userId);
        }
        
        public async Task<Request> AddRequest(Request request)
        {
            return await _RequestRepository.AddAsync(request);
        }
        
        public async Task UpdateRequest(Request request)
        {
            await _RequestRepository.UpdateByUserIdAsync(request);
        }
        
        public async Task DeleteRequest(Request request)
        {
            await _RequestRepository.DeleteAsync(request);
        }
    }
}
