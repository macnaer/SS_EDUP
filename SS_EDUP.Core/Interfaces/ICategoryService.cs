using SS_EDUP.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_EDUP.Core.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetAll();
       
        Category? Get(int id);
        void Create(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}
