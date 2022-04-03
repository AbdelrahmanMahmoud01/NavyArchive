using Application.Features.FileDest.Queries;
using Application.Features.Officer.GetOfficersList;
using Domain.Entites;
using Infrastructure;
using Infrastructure.Contracts;
using Infrastructure.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly IRegister register;
        private readonly IMediator mediator;
        private readonly DataContext context;

        public RegisterController(IRegister register, IMediator mediator, DataContext context)
        {
            this.register = register;
            this.mediator = mediator;
            this.context = context;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterMe()
        {
            ViewBag.Department = new SelectList(await mediator.Send(new GetFileDestQuery()), "Id", "Name");
            //ViewBag.Officers = new SelectList(await mediator.Send(new GetOfficersListCommand()), "Id", "Name");
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterMe(RegisterViewModel model)
        {

            var result = await register.RegisterAsync(model);

            if (result.Succeeded)
                return RedirectToAction("Index", "file");


            foreach (var error in result.Errors)
            { 
                ModelState.AddModelError("", error.Description);
            }
            ViewBag.Department = new SelectList(await mediator.Send(new GetFileDestQuery()), "Id", "Name");
            return View(model);

        }

        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await register.ChecKIfEmailExist(email);
            if (user == null)
                return Json(true);
            else return Json("username taken");

        }

        public async Task<JsonResult> LoadOfficers(int[] cid)
        {
            //return (Json(await mediator.Send(new GetOfficersInDepartment() { Id = cid })));


            var officers = await context.Officers
                .Where(f => cid.Contains(f.DestinationId))
                .Select(f => new Officer
                {
                    Id = f.Id,
                    Name = f.Name
                }).ToListAsync();

            return Json(officers);
        }
    }
}
