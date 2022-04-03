using Infrastructure.Contracts;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class Register : IRegister
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly DataContext context;

        public Register(UserManager<ApplicationUser> userManager,DataContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterViewModel model)
        {
            var user = new ApplicationUser
            { UserName = model.Username ,
              Officer = await context.Officers.FindAsync(model.OfficerId),
              Department = await context.Destinations.FindAsync(model.DepartmentId)
            };
            var result = await userManager.CreateAsync(user, model.Password);

            return result;
        }

        public async Task<ApplicationUser> ChecKIfEmailExist(string email)
        {
            var result = await userManager.FindByEmailAsync(email);

            return result;
        }
    }
}
