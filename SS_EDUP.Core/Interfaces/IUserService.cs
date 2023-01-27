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
        Task<AppUser> GetUserByIdAsync(string id);
    }
}
