using Microsoft.AspNetCore.Mvc;
using GoogleAuthentication.Services;

namespace Authentication.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> GoogleLoginCallback(string code)
        {
            var clientId = "625335937695-epb98brb8er4teiqvh51u2fiahie07ic.apps.googleusercontent.com";
            var url = "https://localhost:7158/login/GoogleLoginCallback";
            var clientsecret = "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";
            var token = await GoogleAuth.GetAuthAccessToken(code, clientId, clientsecret, url);
            var userProfile = await GoogleAuth.GetProfileResponseAsync(token.AccessToken.ToString());
            ViewBag.show = userProfile;
            return View();
        }
    }
}
