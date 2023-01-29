using SS_EDUP.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_EDUP.Core.Entities
{
    public class Course: IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? ImagePath { get; set;}
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        //lessons
        //public ICollection? Lessons { get; set; }
    }
}
