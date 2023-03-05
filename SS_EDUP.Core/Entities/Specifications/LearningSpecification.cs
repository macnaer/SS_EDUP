using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SS_EDUP.Core.Entities.Specifications
{
    public static class Learnings
    {
        // all product specifications
        //public class All : Specification<Learning>
        //{
        //    public All()
        //    {
        //     //   Query.;
        //    }
        //}


        public class CoursesByStudent : Specification<Learning>
        {
            public CoursesByStudent(string studentId)
            {
                Query.Where(x=>x.AppUserId==studentId)
                   .Include(x => x.Course);
            }
        }


    }
}
