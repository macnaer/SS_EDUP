using SS_EDUP.Core.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_EDUP.Core.Interfaces
{
    public interface ICategoriesService
    {
        List<CategoryDto> GetAll();
       
        CategoryDto? Get(int id);
        void Create(CategoryDto categoryDto);
        void Update(CategoryDto categoryDto);
        void Delete(int id);
    }
}
