using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using SS_EDUP.Core.DTO_s;
using SS_EDUP.Core.Entities;
using SS_EDUP.Infrastructure.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_EDUP.Core.AutoMapper
{
    public class AutoMapperUserProfile : Profile
    {
        public AutoMapperUserProfile()
        {
            CreateMap<AppUser, RegisterUserVM>();
            CreateMap<RegisterUserVM, AppUser>();
            CreateMap<AppUser, AppUserDto>();
            CreateMap<AppUserDto, AppUser>().ForMember(dst => dst.UserName, act => act.MapFrom(src => src.Email));
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Course, CourseDto>().ForMember(
                dst => dst.CategoryName,
                act => act.MapFrom(x => GetCategoryName(x))); //?

        }
        static string GetCategoryName(Course course)
        {
            return course.Category?.Name ?? "Not loaded";
        }
    }
}
