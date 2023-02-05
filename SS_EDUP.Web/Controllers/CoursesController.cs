using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SS_EDUP.Core.Entities;
using SS_EDUP.Core.Interfaces;
using SS_EDUP.Infrastructure.Context;

namespace SS_EDUP.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICoursesService _courseService;

        public CoursesController(ICoursesService courseService)
        {
            _courseService = courseService;
        }

    }
}
