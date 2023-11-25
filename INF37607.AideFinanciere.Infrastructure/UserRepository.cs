using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EAISolutionFrontEnd.Core;
using EAISolutionFrontEnd.Core.Interfaces;

namespace EAISolutionFrontEnd.Infrastructure
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(EAISolutionFrontEndContext eAISolutionFrontEndContext) : base(eAISolutionFrontEndContext)
        {
        }

        public Task<User> GetByEmailAsync(string email)
        {
            return _EAISolutionFrontEndContext.Users
              .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
