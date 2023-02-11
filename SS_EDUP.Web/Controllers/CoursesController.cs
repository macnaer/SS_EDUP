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
        public async Task<IActionResult> Index()
        {
            return View(await _coursesService.GetAll());
        }

        private async Task LoadCategories()// ??
        {
            ViewBag.CategoriesList =  new SelectList(
                await _categoriesService.GetAll(), 
                nameof(CategoryDto.Id),
                nameof(CategoryDto.Name)
                );

        }
        // GET: ~/Courses/Create
        public async Task<IActionResult> Create()
        {
            await LoadCategories();
            return View();

        }
        
        // POST: ~/Courses/Create
        [HttpPost]
        public async Task<IActionResult> Create(CourseDto courseDto)
        {
            await _coursesService.Create(courseDto);
            return RedirectToAction(nameof(Index));
        }
        // GET: ~/Products/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var course =  await _coursesService.Get(id);

            if (course == null) return NotFound();

            await LoadCategories();
            return View(course);
        }

        // POST: ~/Products/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(CourseDto courseDto) 
        {
            // TODO: add validations

            await _coursesService.Update(courseDto);

            return RedirectToAction(nameof(Index));
        }

        // GET: ~/Products/Delete/{id}
        public async Task <IActionResult> Delete(int id)
        {
            await _coursesService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
