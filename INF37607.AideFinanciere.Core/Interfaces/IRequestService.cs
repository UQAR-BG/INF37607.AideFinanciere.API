using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EAISolutionFrontEnd.Core.Interfaces
{
    public interface IRequestService
    {
        Task<Request> GetRequest(int userid);
        Task<Request> AddRequest(Request request);
        Task UpdateRequest(Request request);
        Task DeleteRequest(Request request);
       
    }
}
