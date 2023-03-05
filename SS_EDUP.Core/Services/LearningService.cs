using AutoMapper;
using SS_EDUP.Core.DTO_s;
using SS_EDUP.Core.Entities;
using SS_EDUP.Core.Entities.Specifications;
using SS_EDUP.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_EDUP.Core.Services
{
    public class LearningService : ILearningService
    {
        private readonly IRepository<Entities.Learning> _learningRepo;
        private readonly IMapper _mapper;
        public LearningService(IRepository<Entities.Learning> learningRepo, IMapper mapper) {
            this._learningRepo = learningRepo;
            this._mapper = mapper;
        }
        public async Task Add(string studentId, params int[] ids)
        {
            foreach (var id in ids)
            {
                LearningDto learningDto = new LearningDto()
                {
                    CourseID = id,
                    AppUserId = studentId,
                    Progress = 0
                };
               await _learningRepo.Insert(_mapper.Map<Learning>(learningDto));
               await _learningRepo.Save();

            }
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LearningDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<LearningDto?> GetByCourse(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LearningDto>> GetByStudentId(string id)
        {
            var result = await _learningRepo.GetListBySpec(new Learnings.CoursesByStudent(id));
            return _mapper.Map<List<LearningDto>>(result);
        }

        public Task Update(LearningDto learning)
        {
            throw new NotImplementedException();
        }
    }
}
