using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<CourseRegister> CourseRegisters { get; set; }
    }
}