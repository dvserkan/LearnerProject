using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [StringLength(30, ErrorMessage = "Boş Geçilemez")]
        public string CategoryName { get; set; }
        public string CategoryIcon { get; set; }
        public bool CategoryStatus{ get; set; }

        public ICollection<Course> Courses { get; set;}
    }
}