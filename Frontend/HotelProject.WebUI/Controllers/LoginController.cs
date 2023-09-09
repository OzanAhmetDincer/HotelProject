using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.LoginDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginUserDto loginUserDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginUserDto.Username, loginUserDto.Password, false, false);// 3. parametre "isPersistent" değeri; yani girdiğimiz bilgiler tarayıcıda saklanıp saklanmayacağını belirtiriz, 4. parametre ise "lockoutFailure" değeri; yani kullanıcı yanlış şifre veya kullanıcı adı girdiğinde sayım yapar ve default olarak 5 kez hatalı giriş yaparsa 5dk giriş yapmanı engeller.
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Staff");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
    }
}
