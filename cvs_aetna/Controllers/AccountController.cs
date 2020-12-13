using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Okta.AspNetCore;



using Microsoft.AspNetCore.Authorization;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace okta_aspnetcore_mvc_example.Controllers
{
    public class AccountController : Controller
    {


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignInWithSessionToken([FromForm] string sessionToken)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                var properties = new AuthenticationProperties();
                properties.Items.Add("sessionToken", sessionToken);
                properties.RedirectUri = "/Home/Index";

                return Challenge(properties, OktaDefaults.MvcAuthenticationScheme);
            }
            return RedirectToAction("Index", "Home");
            //return RedirectToAction("PostLogin", "Home");
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult SignInRemote()
        {
  
           if (!HttpContext.User.Identity.IsAuthenticated)
            {
                var properties = new AuthenticationProperties();
                //without this, the redirect defaults to entry point of initialization
                //properties.RedirectUri = "/Home/PostLogOut";
                return Challenge(properties, OktaDefaults.MvcAuthenticationScheme);
            }
            return RedirectToAction("Index", "Home");
            //return RedirectToAction("PostLogin", "Home");
        }

        public IActionResult SignOut()
        {
            //sign out both local and okta
            //return new SignOutResult(
            //    new[]
            //    {
            //         OktaDefaults.MvcAuthenticationScheme,
            //         CookieAuthenticationDefaults.AuthenticationScheme,
            //    },
            //    new AuthenticationProperties { RedirectUri = "/Home/Index" });


            List<string> authSchemes = new List<string>()
                {
                     OktaDefaults.MvcAuthenticationScheme,
                     CookieAuthenticationDefaults.AuthenticationScheme,
                };


            AuthenticationProperties authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                RedirectUri = "/Home/Index"
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            SignOutResult signOutResult = new SignOutResult(authSchemes, authProperties);

            return signOutResult;

        }



        //[HttpPost]
        public async Task<IActionResult> LogOut()
        {
            //sign out local only


            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
            //return RedirectToAction("PostLogOut", "Home");

        }




        //public IActionResult SignIn()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult SignIn([FromForm] string sessionToken)
        //{
        //    if (!HttpContext.User.Identity.IsAuthenticated)
        //    {
        //        var properties = new AuthenticationProperties();
        //        properties.Items.Add("sessionToken", sessionToken);
        //        properties.RedirectUri = "/Home/";

        //        return Challenge(properties, OktaDefaults.MvcAuthenticationScheme);
        //    }

        //    return RedirectToAction("Index", "Home");
        //}

        //[HttpPost]
        //public IActionResult SignOut()
        //{
        //    return new SignOutResult(
        //        new[]
        //        {
        //             OktaDefaults.MvcAuthenticationScheme,
        //             CookieAuthenticationDefaults.AuthenticationScheme,
        //        },
        //        new AuthenticationProperties { RedirectUri = "/Home/" });
        //}
    }
}