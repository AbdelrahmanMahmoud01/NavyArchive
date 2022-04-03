using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Infrastructure.Contracts
{
    public interface IAccount
    {
        Task<SignInResult> LogMeIn(LoginViewModels model);
        void LogMeOut();

    }
}
