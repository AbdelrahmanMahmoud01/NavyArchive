using Application.Features.FileDest.Commands.CreateFileDest;
using Application.Features.FileDest.Commands.DeleteFileDest;
using Application.Features.FileDest.Commands.UpdateFileDest;
using Application.Features.FileDest.Queries;
using Application.Features.FileDest.Queries.GetFileDestDetails;
using Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DestController : Controller
    {
        private readonly IMediator mediator;

        public DestController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: DestController
        public async Task<ActionResult> Index()
        {
            var dtos = await mediator.Send(new GetFileDestQuery());
            return View(dtos);
        }

        // GET: DestController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            GetFileDestDeatilsQuery dtos = new GetFileDestDeatilsQuery() { Id = id };
            GetFileDestDetailsViewModel result = await mediator.Send(dtos);

            if (result is null)
                return View("404");

            return View(result);
        }

        // GET: DestController/Create
        public ActionResult Create(int depId = 0, bool IsSuccess = false)
        {
            ViewBag.IsSuccess = IsSuccess;
            ViewBag.depId = depId;

            return View();
        }

        // POST: DestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateFileDestCommand createFileDestCommand)
        {
            if (ModelState.IsValid)
            {
                var result = await mediator.Send(createFileDestCommand);
                return RedirectToAction("Create", new { IsSuccess = true, depId = result });
            }
            return View();
        }

        // GET: DestController/Edit/5
        public async Task<ActionResult> Edit(int id, bool IsSuccess = false)
        {
            UpdateFileDestGet dtos = new UpdateFileDestGet() { Id = id };
            UpdateFileDestCommand result = await mediator.Send(dtos);

            if (result is null)
                return View("404");

            ViewBag.IsSuccess = IsSuccess;

            return View(result);
        }

        // POST: DestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateFileDestCommand updateFileDestCommand)
        {

            if (ModelState.IsValid)
            {
                await mediator.Send(updateFileDestCommand);

                return RedirectToAction(nameof(Edit), new { IsSuccess = true });
            }

            return View();
        }

        // GET: DestController/Delete/5
        public async Task<ActionResult> Delete(int id, bool IsFailed = false)
        {
            DeleteFileDestGet dtos = new DeleteFileDestGet() { Id = id };
            FileDestination result = await mediator.Send(dtos);
            ViewBag.IsFailed = IsFailed;

            if (result is null)
                return View("404");


            return View(result);
        }

        // POST: DestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(DeleteFileDestCommand deleteFileDestCommand)
        {
            try
            {
                await mediator.Send(deleteFileDestCommand);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = deleteFileDestCommand.Id, IsFailed = true });
            }
            
        }
    }
}
