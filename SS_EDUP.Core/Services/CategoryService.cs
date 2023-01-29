using SS_EDUP.Core.Entities;
using SS_EDUP.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_EDUP.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoryRepo;
        public CategoryService(IRepository<Category> categoryRepo)
        {
           this.categoryRepo = categoryRepo;
        }
        public void Create(Category category)
        {
            // create category in db
           categoryRepo.Insert(category);
           categoryRepo.Save(); // submit changes in db
        }

        public void Delete(int id)
        {
            var category = Get(id);

            if (category == null) return; // exception

            categoryRepo.Delete(id);
            categoryRepo.Save();
        }

        public Category? Get(int id)
        {
            if (id < 0) return null; // exception handling

            var category = categoryRepo.GetByID(id);

            if (category == null) return null; // exception handling

            return category;
        }

        public List<Category> GetAll()
        {
            return categoryRepo.Get().ToList();
        }

      

        public void Update(Category category)
        {
            categoryRepo.Update(category);
            categoryRepo.Save();
        }
    }
}
