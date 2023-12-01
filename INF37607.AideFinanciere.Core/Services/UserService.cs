using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

using EAISolutionFrontEnd.Core.Interfaces;
using EAISolutionFrontEnd.SharedKernel.Interfaces;

namespace EAISolutionFrontEnd.Core.Services
{
    // En pratique, le mot de passe doit être cryptée avant sauvegarde dans la BD
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;
        public UserService(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _UserRepository.GetByIdAsync(id);
        }

        public async Task<User> RegisterUser(User user)
        {
            return await _UserRepository.AddAsync(user);
        }

        public async Task<User> UpdateUser(User user)
        {
            return await _UserRepository.UpdateByUserId(user);
        }

        public async Task<User> GetUserByNas(string nas)
        {
            return await _UserRepository.GetByNas(nas);
        }
        
        public async Task<User> GetUserByCodePermanent(string codePermanent)
        {
            return await _UserRepository.GetByCodePermanent(codePermanent);
        }
        
        public async Task<User> AuthenticateUser(string codePermanent, string password)
        {
            User user = await GetUserByCodePermanent(codePermanent);
            if (user != null)
                if (user.Password == password) return user;
            return null;
        }
    }
}
