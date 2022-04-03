using Infrastructure.ViewModels.RolesViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Contracts
{
    public interface IRoles
    {
        Task<IdentityResult> CreateRoleAsyn(CreateRoleViewModel model);
        Task<IEnumerable<IdentityRole>> GetAllRolesAsyn();
        Task<IdentityRole> GetRoleByIdAsync(string id);
        Task<EditRoleViewModel> GetUsersInRoleAsync(IdentityRole role);
        Task<IdentityResult> UpdateRolesAsync(IdentityRole role);
        Task<IEnumerable<UserRoleViewModel>> EditUsersInRole(IdentityRole role);
        
    }
}
