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
        private readonly IUserRepository _UserRepository;
        private readonly IBackEndSystemService _IBackEndSystemService;
        public RequestService(IRequestRepository requestRepository, IUserRepository userRepository, IBackEndSystemService backEndSystemService)
        {
            _RequestRepository = requestRepository;
            _UserRepository = userRepository;
            _IBackEndSystemService = backEndSystemService;
        }


        public async Task<Request> GetRequest(int id)
        {
            return await _RequestRepository.GetByIdWithRequestItemsAsync(id);
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
        public async Task<Request> AddRequestItem(int requestId, RequestItem requestItem)
        {
            Request request = await _RequestRepository.GetByIdAsync(requestId);
            if (request != null)
            {
                request.AddRequestItem(requestItem);

            }
            await _RequestRepository.UpdateAsync(request);
            return await _RequestRepository.GetByIdWithRequestItemsAsync(request.Id);
        }
        public async Task UpdateRequestItem(int requestId, RequestItem requestItem)
        {
            Request request = await _RequestRepository.GetByIdWithRequestItemsAsync(requestId);
            RequestItem ri = request.GetRequestItemsDictionary()[requestItem.Id];
            if (ri != null)
            {
                request.RemoveRequestItem(ri);
            }
            request.AddRequestItem(requestItem);
            await _RequestRepository.UpdateAsync(request);
        }
        public async Task<Request> DeleteRequestItem(int requestId, int requestItemId)
        {
            Request request = await _RequestRepository.GetByIdWithRequestItemsAsync(requestId);
            RequestItem requestItem = request.GetRequestItemsDictionary()[requestItemId];
            request.RemoveRequestItem(requestItem);
            await _RequestRepository.UpdateAsync(request);
            return request;
        }
        public async Task<Request> SubmitRequest(Request request, string directory)
        {
            await _IBackEndSystemService.sendRequestToBackEnd(request, directory);
            request.IsSubmitted = true;
            await UpdateRequest(request);
            return await _RequestRepository.GetByIdWithRequestItemsAsync(request.Id);
        }
        public async Task<IReadOnlyList<Request>> GetUserRequests(int id)
        {
            RequestByUser spec = new RequestByUser(id);
            IReadOnlyList<Request> requests = await _RequestRepository.ListAsync(spec);
            List<Request> requestsToReturn = new List<Request>();
            foreach (Request request in requests)
                requestsToReturn.Add(await _RequestRepository.GetByIdWithRequestItemsAsync(request.Id));
            return (IReadOnlyList<Request>)requestsToReturn;
        }

        public async Task<IReadOnlyList<RequestItem>> GetRequestItems(int id)
        {
            Request request = await _RequestRepository.GetByIdWithRequestItemsAsync(id);
            return (IReadOnlyList<RequestItem>)request.RequestItems;
        }

        public async Task<IReadOnlyList<Request>> SearchUserRequests(int? userId, string search, int item, int nbItem)
        {
            UserRequestSearchSpecification spec = new UserRequestSearchSpecification(userId, search, item, nbItem);
            return await _RequestRepository.ListAsync(spec);

        }
    }

}
