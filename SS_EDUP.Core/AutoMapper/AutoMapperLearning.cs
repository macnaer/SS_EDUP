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
    public class AutoMapperLearning: Profile
    {
        public AutoMapperLearning() {
            CreateMap<Learning, LearningDto>();
            CreateMap<LearningDto,Learning>();
        }
    }
}
