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

        public Task<User> GetByPermanentCode(string code)
        {
            return _EAISolutionFrontEndContext.Users
              .FirstOrDefaultAsync(u => u.PermanentCode == code);
        }
        public async Task UpdateByUserIdAsync(User updatedUser)
        {
            var existingUser = await _EAISolutionFrontEndContext.Users
               .FirstOrDefaultAsync(r => r.Id == updatedUser.Id);
            existingUser.FirstName = updatedUser.FirstName;
            existingUser.LastName = updatedUser.LastName;
            existingUser.PhoneNumber = updatedUser.PhoneNumber;
            existingUser.Email = updatedUser.Email;
            existingUser.CorrespondenceAddress = updatedUser.CorrespondenceAddress;


            _EAISolutionFrontEndContext.Users.Entry(existingUser).CurrentValues.SetValues(existingUser);

            await _EAISolutionFrontEndContext.SaveChangesAsync();
        }
    }
}
