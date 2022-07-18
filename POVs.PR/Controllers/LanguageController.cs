using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace POVs.PR.Controllers
{
    public class LanguageController : Controller
    {
        [HttpGet]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions {
                        Expires = DateTimeOffset.UtcNow.AddYears(1)//,
                        //IsEssential = true,
                        //Path = "/",
                        //HttpOnly = false
                    }
            );
            return LocalRedirect(returnUrl);
        }
    }
}
