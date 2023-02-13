using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SS_EDUP.Core.Entities.Specifications
{
    public static class Courses
    {
        // all product specifications
        public class All : Specification<Course>
        {
            public All()
            {
                Query.Include(x => x.Category);
            }
        }

        public class ByPrice : Specification<Course>
        {
            public ByPrice(decimal from, decimal to)
            {
                Query
                    .Where(x => x.Price >= from && x.Price <= to)
                    .Include(x => x.Category);
            }
        }

        public class ByCategory : Specification<Course>
        {
            public ByCategory(int categoryId)
            {
                Query
                   .Include(x => x.Category)
                   .Where(c=>c.CategoryId== categoryId);
            }
        }
    }
}
