using SS_EDUP.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_EDUP.Core.Interfaces
{
    public interface ICourseService
    {
        List<Course> GetAll();
        List<Course> GetAllCategories();
        Course? Get(int id);
        void Create(Course course);
        void Update(Course course);
        void Delete(int id);
    }
}
