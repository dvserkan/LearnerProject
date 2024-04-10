using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        public double ReviewValue { get; set; }
        public string Comment { get; set; }

        public int CourseID { get; set; }
        public virtual Course Course { get; set; }


        public  int StudentID { get; set; }
        public virtual Student Student { get; set; }
    }
}