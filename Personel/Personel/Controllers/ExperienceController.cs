﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Personel.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager=new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
			ViewBag.v1 = "Deneyim Listesi";
			ViewBag.v2 = "Deneyimler";
			ViewBag.v3 = "Deneyim Listesi";
			var values=experienceManager.TGetList();
            return View(values);
        }
			
        [HttpGet] 
        public IActionResult AddExperience()
        {
            return View();

        }

		//TODO: Experience ekleme de hata var 76.DERS
        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.TAdd(experience);
            return RedirectToAction("Index");
        }

		public IActionResult DeleteExperience(int id)
		{
			var values = experienceManager.GetByID(id);
			experienceManager.TDelete(values);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult EditExperience(int id)
		{
			ViewBag.v1 = "Deneyim Listesi";
			ViewBag.v2 = "Deneyimler";
			ViewBag.v3 = "Deneyim Listesi";
			var values = experienceManager.GetByID(id);
			return View(values);
		}
		[HttpPost]
		public IActionResult EditExperience(Experience experience)
		{
			experienceManager.TUpdate(experience);
			return RedirectToAction("Index");
		}	
	}
}
