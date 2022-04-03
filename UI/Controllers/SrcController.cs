using Application.Features.FileSrc.Queries.GetSrcList;
using Application.Features.FileSrc.Queries.GetSrcDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.FileSrc.Command.CreateSrcFile;
using Application.Features.FileSrc.Command.UpdateSrcFile;
using Domain.Entites;
using Application.Features.FileSrc.Command.DeleteSrcFile;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SrcController : Controller
    {
        private readonly IMediator mediator;

        public SrcController(IMediator mediator )
        {
            this.mediator = mediator;
        }

        // GET: SrcController
        public async Task <ActionResult<IEnumerable<GetSrcListViewModel>>> Index()
        {
            var dtos = await mediator.Send(new GetSrcListQuery());


            return View(dtos);
        }

        // GET: SrcController/Details/5
        public async Task<ActionResult<GetSrcDetailsViewModel>> Details(int id)
        {
            GetSrcDetailsQuery dtos = new GetSrcDetailsQuery() { Id = id };
            GetSrcDetailsViewModel result = await mediator.Send(dtos);

            if (result == null)
                return View("404");

            return View(result);
            
        }

        // GET: SrcController/Create
        public ActionResult Create(int SrcId = 0, bool IsSuccess = false)
        {
            ViewBag.IsSuccess = IsSuccess;
            ViewBag.SrcId = SrcId;

            return View();
        }

        // POST: SrcController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateSrcFileCommand createSrcFileCommand)
        {
            if (ModelState.IsValid)
            {
                var result = await mediator.Send(createSrcFileCommand);

                return RedirectToAction("Create", new { IsSuccess = true , SrcId = result });
            }
            return View(createSrcFileCommand);
        }

        // GET: SrcController/Edit/5
        public async Task<ActionResult> Edit(int id, bool IsSuccess = false)
        {
            UpdateSrcFileGet dtos = new UpdateSrcFileGet() { Id = id };
            UpdateSrcFileCommand result = await mediator.Send(dtos);

            if (result is null)
                return View("404");

            ViewBag.IsSuccess = IsSuccess;
            return View(result);
        }

        // POST: SrcController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateSrcFileCommand updateSrcFileCommand)
        {

            if (ModelState.IsValid)
            {
                var result = await mediator.Send(updateSrcFileCommand);

                return RedirectToAction(nameof(Edit), new { IsSuccess = true});
            }

            return View();
        }

        // GET: SrcController/Delete/5
        public async Task<ActionResult> Delete(int id, bool IsFailed = false)
        {
            DeleteSrcFileGet dtos = new DeleteSrcFileGet() { Id = id };
            FileSource result = await mediator.Send(dtos);
            ViewBag.IsFailed = IsFailed;

            if (result is null)
                return View("404");

            return View(result);
        }

        // POST: SrcController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(DeleteSrcFileCommand deleteSrcFileCommand)
        {
            try
            { 
                await mediator.Send(deleteSrcFileCommand);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = deleteSrcFileCommand.Id, IsFailed = true });
            }
        }
    }
}
