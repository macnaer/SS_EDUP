using SS_EDUP.Core.Entities;
using SS_EDUP.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_EDUP.Core.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> courseRepo;
        public CourseService(IRepository<Course> courseRepo)
        {
            this.courseRepo = courseRepo;
        }
        public void Create(Course course)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Course? Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Course> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public void Update(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
