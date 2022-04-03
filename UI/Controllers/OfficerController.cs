using Application.Features.FileDest.Queries;
using Application.Features.Officer.Commands.CreateOfficer;
using Application.Features.Officer.Commands.DeleteCommand;
using Application.Features.Officer.Commands.UpdateCommand;
using Application.Features.Officer.GetOfficerDetails;
using Application.Features.Officer.GetOfficersList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OfficerController : Controller
    {
        private readonly IMediator mediator;


        public OfficerController(IMediator mediator)
        {
            this.mediator = mediator;

        }

        // GET: OfficerController
        public async Task<ActionResult> Index()
        {
            var dtos = await mediator.Send(new GetOfficersListCommand());
            return View(dtos);
        }

        // GET: OfficerController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            GetOfficerDetailsQuery dtos = new GetOfficerDetailsQuery() {Id = id };
            GetOfficerDetailsViewModel result = await mediator.Send(dtos);

            if (result == null)
                return NotFound();

            return View(result);
        }

        // GET: OfficerController/Create
        public async Task<ActionResult> Create(int officerId = 0, bool IsSuccess = false)
        {
            //var dto = await mediator.Send(new CreateOfficerGetCommand());
            ViewBag.Department = new SelectList(await mediator.Send(new GetFileDestQuery()), "Id", "Name");
            ViewBag.IsSuccess = IsSuccess;
            ViewBag.officerId = officerId;

            return View();
        }

       [HttpPost]
       [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateOfficerPostCommand model)
        {
            if (ModelState.IsValid)
            {
                var result = await mediator.Send(model);
                return RedirectToAction("Create", new { IsSuccess = true, officerId = result });
            }
            return View();
        }

        // GET: OfficerController/Edit/5
        public async Task<ActionResult> Edit(int id, bool IsSuccess = false)
        {
            UpdateOfficerGetCommand dtos = new UpdateOfficerGetCommand() { Id = id };
            UpdateOfficerPostCommand result = await mediator.Send(dtos);

            if (result.Name is null)
                return View("404");

            ViewBag.IsSuccess = IsSuccess;

            return View(result);
        }

        // POST: OfficerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateOfficerPostCommand model)
        {

            if (ModelState.IsValid)
            {
                await mediator.Send(model);
                return RedirectToAction(nameof(Edit), new { IsSuccess = true });
            }

            return View(model);
        }

        // GET: OfficerController/Delete/5
        public async Task<ActionResult> Delete(int id,bool IsFailed = false)
        {
            DeleteGetCommand dtos = new DeleteGetCommand() { Id = id };

            DeletePostCommand officer = await mediator.Send(dtos);

            ViewBag.IsFailed = IsFailed;
            if (officer is null)
                return View("404");

            return View(officer);
        }

        // POST: OfficerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(DeletePostCommand command)
        {
            try
            {
                await mediator.Send(command);

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete) , new {id = command.Id , IsFailed = true });
            }

        }
    }
}
