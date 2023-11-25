using System;
using System.Collections.Generic;
using System.Text;

namespace EAISolutionFrontEnd.Core.Specifications
{
    public class RequestByUser : BaseSpecification<Request>
    {
        public RequestByUser(int userId) : base(x => x.User.Id == userId)
        {
        }
    }

}
