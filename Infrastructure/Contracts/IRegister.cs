using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Infrastructure.Contracts
{
    public interface IRegister
    {
        Task<IdentityResult> RegisterAsync(RegisterViewModel model);


        Task<ApplicationUser> ChecKIfEmailExist(string email);
    }
}
