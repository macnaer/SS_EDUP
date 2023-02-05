using SS_EDUP.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_EDUP.Core.DTO_s
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImagePath { get; set; } = "https://www.freeiconspng.com/thumbs/no-image-icon/no-image-icon-6.png";
        public int CategoryId { get; set; }
        public string ? CategoryName { get; set; }

        
    }
}
