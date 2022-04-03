using Infrastructure.Contracts;
using Infrastructure.ViewModels.RolesViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class Roles : IRoles
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public Roles(RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IdentityResult> CreateRoleAsyn(CreateRoleViewModel model)
        {
            IdentityRole role = new IdentityRole
            {
                Name = model.RoleName
            };

            IdentityResult result = await roleManager.CreateAsync(role);

            return result;

        }

        public async Task<IEnumerable<IdentityRole>> GetAllRolesAsyn()=>
            await roleManager.Roles.ToListAsync();


        public async Task<IdentityRole> GetRoleByIdAsync(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            return role;
        }


        public async Task<EditRoleViewModel> GetUsersInRoleAsync(IdentityRole role)
        {
            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };

            foreach (var user in userManager.Users.ToList())
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return model;
        }

        public async Task<IdentityResult> UpdateRolesAsync(IdentityRole role)
        {
            return await roleManager.UpdateAsync(role);
        }

        public async Task<IEnumerable<UserRoleViewModel>> EditUsersInRole(IdentityRole role)
        {
            var model = new List<UserRoleViewModel>();

            foreach (var user in userManager.Users.ToList())
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                    userRoleViewModel.IsSelected = true;
                else
                    userRoleViewModel.IsSelected = false;


                model.Add(userRoleViewModel);
            }

            return model;
        }
    }
}
