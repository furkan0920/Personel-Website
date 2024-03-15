using Microsoft.AspNetCore.Mvc;

namespace Personel.ViewComponents.Dashboard
{
	public class Last5Projects:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
