using SS_EDUP.Core.Entities;
using SS_EDUP.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_EDUP.Core.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly IRepository<Course> courseRepo;
        public CoursesService(IRepository<Course> courseRepo)
        {
            this.courseRepo = courseRepo;
        }
        public void Create(Course course)
        {
            courseRepo.Insert(course);
            courseRepo.Save();
        }

        public void Delete(int id)
        {
           var  course =  Get(id);
            if (course != null)
            {
                courseRepo.Delete(id);
                courseRepo.Save();
            }
        }

        public Course? Get(int id)
        {
            if(id <0)
                return null;
            var course = courseRepo.GetByID(id);
            return course;
        }

        public List<Course> GetAll()
        {
            return courseRepo.Get(includeProperties: "Category").ToList();
        }

       
        public void Update(Course course)
        {
           courseRepo.Update(course);
           courseRepo.Save();
        }
    }
}
