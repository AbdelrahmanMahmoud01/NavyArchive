using Infrastructure;
using Infrastructure.Contracts;
using Infrastructure.ViewModels.RolesViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly IRoles roles;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public RolesController(IRoles roles , UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.roles = roles;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }


        public IActionResult CreateRole()=> View();

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await roles.CreateRoleAsyn(model);

                if (result.Succeeded)
                    return RedirectToAction("ListRoles", "Roles");

                foreach (var item in result.Errors)
                    ModelState.AddModelError("", item.Description);

            }
            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> ListRoles()
        {
            var listRoles = await roles.GetAllRolesAsyn();

            return View(listRoles);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roles.GetRoleByIdAsync(id);

            if (role == null)
                return NotFound();

            var usersInRole = await roles.GetUsersInRoleAsync(role);
            return View(usersInRole);
        }


        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roles.GetRoleByIdAsync(model.Id);

            if (role == null)
                return NotFound();


            role.Name = model.RoleName;
            var result = await roles.UpdateRolesAsync(role);

            if (result.Succeeded)
                return RedirectToAction(nameof(ListRoles));

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await roles.GetRoleByIdAsync(roleId);

            if (role == null)
                return NotFound();
          
            var model = await roles.EditUsersInRole(role);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {
            var role = await roles.GetRoleByIdAsync(roleId);

            if (role == null)
                return View("NotFound");

            for (int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;

                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = roleId });
                }
            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }


        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                try
                {
                    //throw new Exception("Test Exception");

                    var result = await roleManager.DeleteAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ListRoles");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View("ListRoles");
                }
                catch (DbUpdateException ex)
                {
                    ViewBag.ErrorTitle = $"{role.Name} role is in use";
                    ViewBag.ErrorMessage = $"{role.Name} role cannot be deleted as there are users " +
                        $"in this role. If you want to delete this role, please remove the users from " +
                        $"the role and then try to delete";
                    return View("Error");
                }
            }
        }
    }
}
