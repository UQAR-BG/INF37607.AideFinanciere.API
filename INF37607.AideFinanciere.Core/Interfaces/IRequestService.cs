using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EAISolutionFrontEnd.Core.Interfaces
{
    public interface IRequestService
    {
        bool IsPending(int userid);
        Task<Request> GetRequest(int id);
        Task<List<Request>> GetRequests(int userid);
        Task<List<Request>> GetAllActiveRequests(int userid);
        Task<Request> AddRequest(Request request);
        Task UpdateRequest(Request request);
        Task DeleteRequest(Request request);
       
    }
}
