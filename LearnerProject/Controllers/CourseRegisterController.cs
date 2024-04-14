using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
	public class CourseRegisterController : Controller
	{
		LearnerContext c = new LearnerContext();
		// GET: CourseRegister
		public ActionResult Index()
		{
			var values = c.CourseRegisters.ToList();
			return View(values);
		}

		[HttpGet]
		public ActionResult AddCourseRegister()
		{
			List<SelectListItem> list = (from x in c.Courses
										 select new SelectListItem
										 {
											 Text = x.CourseName,
											 Value = x.CourseID.ToString()
										 }).ToList();

			ViewBag.course = list;

			List<SelectListItem> lis = (from x in c.Students
										select new SelectListItem
										{
											Text = x.NameSurname,
											Value = x.StudentID.ToString()
										}).ToList();
			ViewBag.student = lis;


			return View();
		}

		[HttpPost]
		public ActionResult AddCourseRegister(CourseRegister p)
		{
			c.CourseRegisters.Add(p);
			c.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteCourseRegister(int id)
		{
			var values = c.CourseRegisters.Find(id);
			c.CourseRegisters.Remove(values);
			c.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult EditCourseRegister(int id)
		{

			List<SelectListItem> list = (from x in c.Courses
										 select new SelectListItem
										 {
											 Text = x.CourseName,
											 Value = x.CourseID.ToString()
										 }).ToList();

			ViewBag.course = list;

			List<SelectListItem> lis = (from x in c.Students
										select new SelectListItem
										{
											Text = x.NameSurname,
											Value = x.StudentID.ToString()
										}).ToList();
			ViewBag.student = lis;


			var values = c.CourseRegisters.Find(id);
			return View(values);
		}

		[HttpPost]
		public ActionResult EditCourseRegister(CourseRegister p)
		{
			var values = c.CourseRegisters.Find(p.CourseRegisterID);
			values.StudentID = p.StudentID;
			values.CourseID = p.CourseID;
			c.SaveChanges();
			return RedirectToAction("Index");

		}
	}
}