using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Personel.Areas.Writer.Models;

namespace Personel.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class RegisterController : Controller
    {


        private readonly UserManager<WriterUser> _userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View( new UserRegisterViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {
                WriterUser w = new WriterUser()
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    Email = p.Mail,
                    UserName = p.UserName,
                    ImageUrl = p.ImageUrl
                };
            if (p.ConfirmPassword == p.Password)
            {

                var result = await _userManager.CreateAsync(w);
          

                if (result.Succeeded )
                {
                    return RedirectToAction("/Index/", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
              }

            return View(p);
        }
    }
}
