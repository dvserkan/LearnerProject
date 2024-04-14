using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
	public class CourseController : Controller
	{
		LearnerContext c = new LearnerContext();
		// GET: Course
		public ActionResult Index()
		{
			var values = c.Courses.ToList();
			return View(values);
		}

		[HttpGet]
		public ActionResult AddCourse()
		{
			List<SelectListItem> list = (from y in c.Categories
										 select new SelectListItem
										 {
											 Text = y.CategoryName,
											 Value = y.CategoryID.ToString()
										 }).ToList();

			ViewBag.addcategory = list;
			return View();
		}

		[HttpPost]
		public ActionResult AddCourse(Course p)
		{
			c.Courses.Add(p);
			c.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteCourse(int id)
		{
			var value = c.Courses.Find(id);
			c.Courses.Remove(value);
			c.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult EditCourse(int id)
		{
			List<SelectListItem> list = (from y in c.Categories select new SelectListItem
			{
				 Text = y.CategoryName,
				 Value = y.CategoryID.ToString()
			}).ToList();

			ViewBag.category = list;

			var value = c.Courses.Find(id);
			return View(value);
		}

		[HttpPost]
		public ActionResult EditCourse(Course p)
		{
			var value = c.Courses.Find(p.CourseID);
			value.CourseName = p.CourseName;
			value.ImageUrl = p.ImageUrl;
			value.Description = p.Description;
			value.Price = p.Price;
			value.CategoryID = p.CategoryID;
			c.SaveChanges();
			return RedirectToAction("Index");
		}

	}
}