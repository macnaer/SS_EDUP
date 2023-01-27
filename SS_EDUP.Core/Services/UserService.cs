using Microsoft.AspNet.Identity;
using SS_EDUP.Core.Entities;
using SS_EDUP.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_EDUP.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserManager<AppUser>> _userRepository;

        public UserService(IRepository<UserManager<AppUser>> userRepository)
        {
            _userRepository = userRepository;
        }

        public void Create(AppUser user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public AppUser? Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}
