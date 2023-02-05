using AutoMapper;
using SS_EDUP.Core.DTO_s;
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
        private readonly IRepository<Course> _courseRepo;
        private readonly IRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;
        public CoursesService(IRepository<Course> courseRepo, 
            IRepository<Category> categoryRepo, 
            IMapper mapper)
        {
            this._courseRepo = courseRepo;
            this._categoryRepo = categoryRepo;
            this._mapper = mapper;
        }
        public void Create(CourseDto courseDto)
        {
            _courseRepo.Insert(_mapper.Map<Course>(courseDto));
            _courseRepo.Save();
        }

        public void Delete(int id)
        {
           var  course =  Get(id);
            if (course != null)
            {
                _courseRepo.Delete(id);
                _courseRepo.Save();
            }
        }

        public CourseDto? Get(int id)
        {
            if(id <0)
                return null;
            var course = _courseRepo.GetByID(id);
            return _mapper.Map<CourseDto>(course);
        }

        public List<CourseDto> GetAll()
        {
            return _mapper.Map< List<CourseDto> >(_courseRepo.Get(includeProperties: "Category").ToList());
        }

       
        public void Update(CourseDto courseDto)
        {
           _courseRepo.Update(_mapper.Map<Course>(courseDto));
           _courseRepo.Save();
        }
    }
}

