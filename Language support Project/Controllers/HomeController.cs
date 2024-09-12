using Language_support_Project.Models;
using Language_support_Project.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Web.Services3;
using System.Diagnostics;

namespace Language_support_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LanguageService _localization;

        

        public HomeController(ILogger<HomeController> logger, LanguageService localization)
        {
            _logger = logger;
            _localization = localization;
        }

        public IActionResult Index()
        {
            ViewBag.Welcome = _localization.GetKey("Welcome").Value;
            var currentculture = Thread.CurrentThread.CurrentCulture.Name;

            return View();
        }



        public IActionResult ChangeLanguage(string culture, DateTimeOffset dateTimeOffset)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
            {
                  Expires = DateTimeOffset.UtcNow.AddYears(1)
            });
          

            return Redirect(Request.Headers["Referer"].ToString());


        }











       public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
