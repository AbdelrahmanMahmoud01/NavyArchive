using Infrastructure.Contracts;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class Loging : IAccount
    {

        private readonly SignInManager<ApplicationUser> signInManager;
        public Loging(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task<SignInResult> LogMeIn(LoginViewModels model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Username,
                model.Password, model.RememberMe, false);

            return result;
        }

        public async void LogMeOut()
        {
            await signInManager.SignOutAsync();
        }
    }
}
