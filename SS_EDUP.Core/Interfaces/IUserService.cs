using Microsoft.AspNetCore.Identity;
using SS_EDUP.Core.Entities;
using SS_EDUP.Core.Services;
using SS_EDUP.Core.ViewModels.User;
using SS_EDUP.Infrastructure.ViewModels.User;
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
        Task<ServiceResponse> RegisterUserAsync(RegisterUserVM model);
        Task<ServiceResponse> LoginUserAsync(LoginUserVM model);
    }
}
