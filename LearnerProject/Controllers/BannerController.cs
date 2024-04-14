using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class BannerController : Controller
    {
        LearnerContext c = new LearnerContext();
        // GET: Banner
        public ActionResult Index()
        {
            var values = c.Banners.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddBanner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBanner(Banner p)
        {
            c.Banners.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBanner(int id)
        {
            var values = c.Banners.Find(id);
            c.Banners.Remove(values);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditBanner(int id)
        {
            var values = c.Banners.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult EditBanner(Banner p)
        {
            var values = c.Banners.Find(p.BannerID);
            values.Title = p.Title;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}