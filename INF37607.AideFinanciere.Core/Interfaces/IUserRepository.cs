using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EAISolutionFrontEnd.SharedKernel.Interfaces;
using EAISolutionFrontEnd.Core;

namespace EAISolutionFrontEnd.Core.Interfaces
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> GetByNas(string nas);
        Task<User> GetByCodePermanent(string codePermanent);
        Task<User> UpdateByUserId(User user);
    }
}
