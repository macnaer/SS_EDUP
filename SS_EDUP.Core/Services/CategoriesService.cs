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
    public class CategoriesService : ICategoriesService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Category> _categoryRepo;
       

        public CategoriesService(IRepository<Category> categoryRepo, IMapper mapper)
        {
           this._categoryRepo = categoryRepo;
            this._mapper = mapper;
        }
        public void Create(CategoryDto categoryDto)
        {
            // create category in db
           _categoryRepo.Insert(_mapper.Map<Category>(categoryDto));
           _categoryRepo.Save(); // submit changes in db
        }

        public void Delete(int id)
        {
            var categoryDto = Get(id);

            if (categoryDto == null) return; // exception

            _categoryRepo.Delete(id);
            _categoryRepo.Save();
        }

        public CategoryDto? Get(int id)
        {
            if (id < 0) return null; // exception handling

            var category = _categoryRepo.GetByID(id);

            if (category == null) return null; // exception handling

            return _mapper.Map<CategoryDto>(category);
        }

        public List<CategoryDto> GetAll()
        {
            var result = _categoryRepo.Get().ToList();
            return _mapper.Map<List<CategoryDto>>(result);
        }

      

        public void Update(CategoryDto categoryDto)
        {
            _categoryRepo.Update(_mapper.Map<Category>(categoryDto));
            _categoryRepo.Save();
        }
    }
}
