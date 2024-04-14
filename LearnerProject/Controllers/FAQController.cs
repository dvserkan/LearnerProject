using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class FaqController : Controller
    {
        // GET: FAQ
        LearnerContext c = new LearnerContext();
        public ActionResult Index()
        {
            var values = c.FAQs.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddFaq()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFaq(FAQ p )
        {
            p.Status = true;
            c.FAQs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteFaq(int id)
        {
            var values = c.FAQs.Find(id);
            c.FAQs.Remove(values);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditFaq(int id)
        {
            var values = c.FAQs.Find(id);
            return View(values);
        }


        [HttpPost]
        public ActionResult EditFaq(FAQ p)
        {
            var values = c.FAQs.Find(p.FaqID);
            values.Question = p.Question;
            values.Answer = p.Answer;
            values.Status = p.Status;
            values.ImageUrl = p.ImageUrl;
            c.SaveChanges();
            return RedirectToAction("Index");

		}

    }
}