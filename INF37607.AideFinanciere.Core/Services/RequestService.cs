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

        public async Task<Request> GetRequest(int userId)
        {
            return await _RequestRepository.GetByIdAsync(userId);
        }
        public async Task<Request> AddRequest(Request request)
        {
            return await _RequestRepository.AddAsync(request);
        }
        public async Task UpdateRequest(Request request)
        {
            await _RequestRepository.UpdateAsync(request);
        }
        public async Task DeleteRequest(Request request)
        {
            await _RequestRepository.DeleteAsync(request);
        }
     
    }

}
