using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SS_EDUP.Core.DTO_s;
using SS_EDUP.Core.Entities;
using SS_EDUP.Core.Interfaces;
using SS_EDUP.Infrastructure.Context;

namespace SS_EDUP.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICoursesService _coursesService;
        private readonly ICategoriesService _categoriesService; 

        public CoursesController(ICoursesService coursesService, ICategoriesService categoriesService)
        {
            _coursesService = coursesService;
            _categoriesService = categoriesService;
        }
        public IActionResult Index()
        {
            return View(_coursesService.GetAll());
        }

        private void LoadCategories()// ??
        {
            ViewBag.CategoriesList = new SelectList(
                _categoriesService.GetAll(), 
                nameof(CategoryDto.Id), 
                nameof(CategoryDto.Name)
                );
            
        }
        // GET: ~/Courses/Create
        public IActionResult Create()
        {
            LoadCategories();
            return View();

        }
        
        // POST: ~/Courses/Create
        [HttpPost]
        public IActionResult Create(CourseDto courseDto)
        {
            _coursesService.Create(courseDto);
            return RedirectToAction(nameof(Index));
        }
        // GET: ~/Products/Edit/{id}
        public IActionResult Edit(int id)
        {
            var course = _coursesService.Get(id);

            if (course == null) return NotFound();

            LoadCategories();
            return View(course);
        }

        // POST: ~/Products/Edit
        [HttpPost]
        public IActionResult Edit(CourseDto courseDto) 
        {
            // TODO: add validations

            _coursesService.Update(courseDto);

            return RedirectToAction(nameof(Index));
        }

        // GET: ~/Products/Delete/{id}
        public IActionResult Delete(int id)
        {
            _coursesService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
