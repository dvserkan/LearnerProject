using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }


        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }


        public ICollection<Review> Reviews { get; set; }

        public ICollection<CourseRegister> CourseRegisters { get; set; }

    }
}