using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Personel.ViewComponents.Experience
{
	public class ExperienceList:ViewComponent
	{
		ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());

		public IViewComponentResult Invoke()
		{
			var values = experienceManager.TGetList();
			return View(values);
		}
	}
}
