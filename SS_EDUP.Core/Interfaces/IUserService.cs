using Microsoft.AspNetCore.Identity;
using SS_EDUP.Core.DTO_s;
using SS_EDUP.Core.Entities;
using SS_EDUP.Core.Services;
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
        Task<ServiceResponse> RegisterUserAsync(AppUser model, string password);
        Task<ServiceResponse> LoginUserAsync(LoginUserDto model);
    }
}
