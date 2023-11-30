using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EAISolutionFrontEnd.Core.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);

        Task<User> GetUserByPermanentCode(string email);
        Task<User> RegisterUser(User user);

        Task UpdateUser(User user);
        Task<User> AuthenticateUser(string CodePermanent, string password);

    }
}
