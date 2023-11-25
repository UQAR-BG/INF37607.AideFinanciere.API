using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EAISolutionFrontEnd.Core.Interfaces
{
    public interface IRequestService
    {
        Task<Request> GetRequest(int id);
        Task<Request> AddRequest(Request request);
        Task UpdateRequest(Request request);
        Task DeleteRequest(Request request);
        Task<Request> AddRequestItem(int requestId, RequestItem requestItem);
        Task UpdateRequestItem(int requestId, RequestItem requestItem);
        Task<Request> DeleteRequestItem(int requestId, int requestItemId);
        Task<Request> SubmitRequest(Request request, string directory);
        Task<IReadOnlyList<Request>> GetUserRequests(int id);
        Task<IReadOnlyList<RequestItem>> GetRequestItems(int id);
        Task<IReadOnlyList<Request>> SearchUserRequests(int? userId, string search, int item, int nbItem);

    }
}
