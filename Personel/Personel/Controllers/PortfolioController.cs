using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Personel.Controllers
{
	public class PortfolioController : Controller
	{
		PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
		public IActionResult Index()
		{
			ViewBag.v1 = "Proje Listesi";
			ViewBag.v2 = "Projelerim";
			ViewBag.v3 = "Proje Listesi";
			var values = portfolioManager.TGetList();
			return View(values);
		}

		[HttpGet]
		public IActionResult AddPortfolio()
		{
			ViewBag.v1 = "Proje Listesi";
			ViewBag.v2 = "Projelerim";
			ViewBag.v3 = "Proje Ekleme";
			return View();
		}
		//TODO: Portfolio ekleme güncelleme de sıkıntı var veritabanı null bırakılmadığından kaynaklanabilir

		[HttpPost]
		public IActionResult AddPortfolio(Portfolio p)
		{
			PortfolioValidator validations = new PortfolioValidator();
			ValidationResult results = validations.Validate(p);
			if (results.IsValid)
			{
				portfolioManager.TAdd(p);
				return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}
		public IActionResult DeletePortfolio(int id)
		{
			var values = portfolioManager.GetByID(id);
			portfolioManager.TDelete(values);
			return RedirectToAction("Index");

		}

		public IActionResult EditPortfolio(int id)
		{
			ViewBag.v1 = "Proje Listesi";
			ViewBag.v2 = "Projelerim";
			ViewBag.v3 = "Proje Düzenleme";
			var values = portfolioManager.GetByID(id);
			return View(values);
		}
		[HttpPost]
		public IActionResult EditPortfolio(Portfolio portfolio)
		{
			PortfolioValidator validations=new PortfolioValidator();
			ValidationResult result = validations.Validate(portfolio);	
			if (result.IsValid)
			{
			portfolioManager.TUpdate(portfolio);
			return RedirectToAction("Index");

			}
			else
			{
				foreach(var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
				}
			}
			return View();
		}
	}
}
