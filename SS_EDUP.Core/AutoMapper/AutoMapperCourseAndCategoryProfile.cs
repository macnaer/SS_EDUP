using AutoMapper;
using SS_EDUP.Core.DTO_s;
using SS_EDUP.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_EDUP.Core.AutoMapper
{
    public class AutoMapperCourseAndCategoryProfile : Profile
    {
        public AutoMapperCourseAndCategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Course, CourseDto>().ForMember(
                dst => dst.CategoryName,
                act => act.MapFrom(x => GetCategoryName(x)));
            CreateMap<CourseDto, Course>();
        }

        static string GetCategoryName(Course course)
        {
            return course.Category?.Name ?? "Not loaded";
        }
    }
}
