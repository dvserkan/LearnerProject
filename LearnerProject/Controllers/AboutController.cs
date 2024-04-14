using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
	public class AboutController : Controller
	{
		LearnerContext c = new LearnerContext();
		// GET: About
		public ActionResult Index()
		{
			var list = c.Abouts.ToList();
			return View(list);
		}
		[HttpGet]
		public ActionResult AddAbout()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddAbout(About p)
		{
			c.Abouts.Add(p);
			c.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteAbout(int id)
		{
			var values = c.Abouts.Find(id);
			c.Abouts.Remove(values);
			c.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult EditAbout(int id)
		{
			var values = c.Abouts.Find(id);
			return View(values);
		}
		[HttpPost]
		public ActionResult EditAbout(About p)
		{
			var val = c.Abouts.Find(p.AboutID);
			val.Title = p.Title;
			val.Description = p.Description;
			val.ImageUrl = p.ImageUrl;
			val.Item1 = p.Item1;
			val.Item2 = p.Item2;
			val.Item3 = p.Item3;
			c.SaveChanges();
			return RedirectToAction("Index");
		}






	}
}