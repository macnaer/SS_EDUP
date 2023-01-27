using SS_EDUP.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_EDUP.Core.Interfaces
{
    public interface IUserService
    {
        List<AppUser> GetAll();
        AppUser? Get(int id);
        void Create(AppUser user);
        void Update(AppUser user);
        void Delete(int id);
    }
}
