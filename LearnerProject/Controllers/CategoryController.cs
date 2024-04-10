using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        LearnerContext c = new LearnerContext();
        public ActionResult Index()
        {
            var values = c.Categories.Where(x => x.CategoryStatus == true).ToList();
            return View(values);
        }

        public ActionResult DeleteCategory(int id)
        {
            var values = c.Categories.Find(id);
            values.CategoryStatus = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            p.CategoryStatus = true;
            c.Categories.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var values = c.Categories.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            var values = c.Categories.Find(p.CategoryID);
            values.CategoryName = p.CategoryName;
            values.CategoryIcon = p.CategoryIcon;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
