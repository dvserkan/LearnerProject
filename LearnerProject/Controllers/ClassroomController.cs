using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
	public class ClassroomController : Controller
	{
		LearnerContext c = new LearnerContext();
		// GET: Classroom
		public ActionResult Index()
		{
			var values = c.Classrooms.ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult AddClassroom()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddClassroom(Classroom p)
		{
			c.Classrooms.Add(p);
			c.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteClassroom(int id)
		{
			var values = c.Classrooms.Find(id);
			c.Classrooms.Remove(values);
			c.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult EditClassroom(int id)
		{
			var values = c.Classrooms.Find(id);
			return View(values);
		}

		[HttpPost]
		public ActionResult EditClassroom(Classroom p )
		{
			var values = c.Classrooms.Find(p.ClassroomID);
			values.ClassroomName = p.ClassroomName;
			values.Description = p.Description;
			values.Icon = p.Icon;
			c.SaveChanges();
			return RedirectToAction("Index");
		}


	}
}