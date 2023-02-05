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
        List<CourseDto> GetAll(); //...
        CourseDto? Get(int id);
        void Create(CourseDto course);
        void Update(CourseDto course);
        void Delete(int id);
    }
}
