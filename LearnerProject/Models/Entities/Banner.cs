using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class Banner
    {
        [Key]
        public int BannerID { get; set; }
        public string Title { get; set; }
    }
}