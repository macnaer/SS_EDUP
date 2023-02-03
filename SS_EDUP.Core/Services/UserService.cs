using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SS_EDUP.Core.Entities;
using SS_EDUP.Core.Interfaces;
using SS_EDUP.Core.ViewModels.User;
using SS_EDUP.Infrastructure.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_EDUP.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public Task<AppUser> GetUserByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse> LoginUserAsync(LoginUserVM model)
        {
            AppUser user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new ServiceResponse
                {
                    Success = false,
                    Message = "User or password incorrect."
                };
            }

            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if (result)
            {
                await _signInManager.SignInAsync(user, false);
                return new ServiceResponse
                {
                    Success = true,
                    Message = "User logged in successfully."
                };
            }

            return new ServiceResponse
            {
                Success = false,
                Message = "User or password incorrect."
            };
        }

        public Task<ServiceResponse> RegisterUserAsync(AppUser model, string password)
        {
            throw new NotImplementedException();
        }
    }
}
