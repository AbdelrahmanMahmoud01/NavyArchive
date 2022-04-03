using Infrastructure.Contracts;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IAccount account;


        public LoginController(IAccount account)
        {
            this.account = account;

        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Loging()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Loging(LoginViewModels model)
        {
            if (ModelState.IsValid)
            {
                var result = await Task.Run(() => account.LogMeIn(model).Result);

                if (result.Succeeded)
                    return RedirectToAction("index", "file");
                else
                    ModelState.AddModelError(string.Empty,"من فضلك تأكد من أسم المستخدم والرقم السري");

            }

            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            await Task.Run(()=> account.LogMeOut());
            return RedirectToAction("index", "file");
        }

        [AcceptVerbs("POST", "GET")]
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}
