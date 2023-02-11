using AutoMapper;
using SS_EDUP.Core.DTO_s;
using SS_EDUP.Core.Entities;
using SS_EDUP.Core.Entities.Specifications;
using SS_EDUP.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public async Task Create(CourseDto courseDto)
        {
            await _courseRepo.Insert(_mapper.Map<Course>(courseDto));
            await _courseRepo.Save();
        }

        public  async Task Delete(int id)
        {
           var  course =  await Get(id);
            if (course != null)
            {
                await _courseRepo.Delete(id);
                await _courseRepo.Save();
            }
        }

        public async Task<CourseDto?> Get(int id)
        {
            if(id <0)
                return null;
            var course = await _courseRepo.GetByID(id);
            return _mapper.Map<CourseDto>(course);
        }

        public async Task<List<CourseDto>> GetAll()
        {
            //return  _mapper.Map<List<CourseDto>>(await _courseRepo.Get(includeProperties: "Category")) ;
            var result = await _courseRepo.GetListBySpec(new Courses.All());
            return _mapper.Map<List<CourseDto>>(result);
        }

       
        public async Task  Update(CourseDto courseDto)
        {
           await _courseRepo.Update(_mapper.Map<Course>(courseDto));
           await _courseRepo.Save();
        }

        public async Task<List<CourseDto>> GetByCategory(int id) {
            var result = await _courseRepo.GetListBySpec(new Courses.ByCategory(id));
            return _mapper.Map<List<CourseDto>>(result);
        }
    }
}

