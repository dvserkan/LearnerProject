using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class Classroom
    {
        [Key]
        public int ClassroomID { get; set; }
        public string ClassroomName { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }


    }
}