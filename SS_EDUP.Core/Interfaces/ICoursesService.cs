using SS_EDUP.Core.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_EDUP.Core.Interfaces
{
    public interface ICoursesService
    {
        Task<List<CourseDto>> GetAll(); //...
        Task<CourseDto?> Get(int id);
        Task<List<CourseDto?>> Get(int[] ids);
        Task Create(CourseDto course);
        Task Update(CourseDto course);
        Task Delete(int id);
        Task<List<CourseDto>> GetByCategory(int id);
    }
}
