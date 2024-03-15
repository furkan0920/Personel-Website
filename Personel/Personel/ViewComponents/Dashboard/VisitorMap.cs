using Microsoft.AspNetCore.Mvc;

namespace Personel.ViewComponents.Dashboard
{
	public class VisitorMap:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
