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

        public Task<Request> GetByIdWithRequestItemsAsync(int id)
        {
            return _EAISolutionFrontEndContext.Requests
              .Include(r => r.RequestItems)
              .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
