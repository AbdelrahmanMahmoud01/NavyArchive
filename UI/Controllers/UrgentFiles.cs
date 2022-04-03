using Application.Features.Pagintaion;
using Domain.Entites;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.ViewModels;

/*
 * This is not an excuse but i didnt had time to make this feature with
 * CQRS and MidtR , so i made it with tasty spaghetti code  
 * and i dont think i will clean it cuz i completed my military service
 * 
 * hope you wont judge me with this controller 
 */

namespace UI.Controllers
{
    public class UrgentFiles : Controller
    {
        private readonly DataContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public UrgentFiles(DataContext context,UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize(Policy = "UrgentFilesPolicy")]
        public async Task<ActionResult> Index(int pg = 1)
        {
            const int pageSize = 5;
            if (pg < 1)
                pg = 1;

            var userId = userManager.GetUserId(HttpContext.User);

            ApplicationUser user = userManager.FindByIdAsync(userId).Result;



            int recSkip = (pg - 1) * pageSize;

            if (User.HasClaim(x => x.Type == "Officer"))
            {
                var result = await context.FilesInfo
                .Include(x => x.FileInfoSoruce)
                .ThenInclude(x => x.FileSource)
                .Include(x => x.FileInfoOfficers)
                .ThenInclude(x => x.Officer)
                .ThenInclude(x => x.Destination)
                .Where(x => x.FileInfoOfficers.Select(x => x.OfficerId).Contains(user.Officer.Id))
                .Where(x => x.ProcedcureTage == null && x.ProcedcureUrl == null)
                .OrderBy(x => x.ReminderDate)
                .AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();


                int recsCount = result.Count();
                var pager = new Pager(recsCount, pg, pageSize);

                var data = result.Skip(recSkip).Take(pager.PageSize).ToList();

                ViewBag.Pager = pager;

                return View(data);
            }
            else if (User.HasClaim(x => x.Type == "HeadDepartment"))
            {
                var result = await context.FilesInfo
                .Include(x => x.FileInfoSoruce)
                .ThenInclude(x => x.FileSource)
                .Include(x => x.FileInfoOfficers)
                .ThenInclude(x => x.Officer)
                .ThenInclude(x => x.Destination)
                .Where(x => x.FileInfoOfficers.Select(x => x.Officer.Destination.Id).Contains(user.Department.Id))
                .Where(x => x.ProcedcureTage == null && x.ProcedcureUrl == null)
                .OrderBy(x => x.ReminderDate)
                .AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();


                int recsCount = result.Count();
                var pager = new Pager(recsCount, pg, pageSize);

                var data = result.Skip(recSkip).Take(pager.PageSize).ToList();

                ViewBag.Pager = pager;

                return View(data);
            }
            else
            {
                var result = await context.FilesInfo
                .Include(x => x.FileInfoSoruce)
                .ThenInclude(x => x.FileSource)
                .Include(x => x.FileInfoOfficers)
                .ThenInclude(x => x.Officer)
                .ThenInclude(x => x.Destination)
                .Where(x => x.ProcedcureTage == null && x.ProcedcureUrl == null)
                .OrderBy(x => x.ReminderDate)
                .AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();

                int recsCount = result.Count();
                var pager = new Pager(recsCount, pg, pageSize);

                var data = result.Skip(recSkip).Take(pager.PageSize).ToList();

                ViewBag.Pager = pager;

                return View(data);
            }
        }

        [Authorize(Policy = "SearchPolicy")]
        public async Task<ActionResult> Search(string term, int critera, int pg = 1)
        {
            if (term == string.Empty || term is null)
            {
                const int pageSize = 5;
                if (pg < 1)
                    pg = 1;

                var userId = userManager.GetUserId(HttpContext.User);

                ApplicationUser user = userManager.FindByIdAsync(userId).Result;



                int recSkip = (pg - 1) * pageSize;

                if (User.HasClaim(x => x.Type == "Officer"))
                {
                    var result = await context.FilesInfo
                    .Include(x => x.FileInfoSoruce)
                    .ThenInclude(x => x.FileSource)
                    .Include(x => x.FileInfoOfficers)
                    .ThenInclude(x => x.Officer)
                    .ThenInclude(x => x.Destination)
                    .Where(x => x.FileInfoOfficers.Select(x => x.OfficerId).Contains(user.Officer.Id))
                    .Where(x => x.ProcedcureTage == null && x.ProcedcureUrl == null)
                    .OrderBy(x => x.ReminderDate)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .ToListAsync();


                    int recsCount = result.Count();
                    var pager = new Pager(recsCount, pg, pageSize);

                    var data = result.Skip(recSkip).Take(pager.PageSize).ToList();

                    ViewBag.Pager = pager;

                    return View(nameof(Index), data);
                }
                else if (User.HasClaim(x => x.Type == "HeadDepartment"))
                {
                    var result = await context.FilesInfo
                    .Include(x => x.FileInfoSoruce)
                    .ThenInclude(x => x.FileSource)
                    .Include(x => x.FileInfoOfficers)
                    .ThenInclude(x => x.Officer)
                    .ThenInclude(x => x.Destination)
                    .Where(x => x.FileInfoOfficers.Select(x => x.Officer.Destination.Id).Contains(user.Department.Id))
                    .Where(x => x.ProcedcureTage == null && x.ProcedcureUrl == null)
                    .OrderBy(x => x.ReminderDate)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .ToListAsync();



                    int recsCount = result.Count();
                    var pager = new Pager(recsCount, pg, pageSize);

                    var data = result.Skip(recSkip).Take(pager.PageSize).ToList();

                    ViewBag.Pager = pager;

                    return View(nameof(Index), data);
                }
                else
                {
                    var result = await context.FilesInfo
                    .Include(x => x.FileInfoSoruce)
                    .ThenInclude(x => x.FileSource)
                    .Include(x => x.FileInfoOfficers)
                    .ThenInclude(x => x.Officer)
                    .ThenInclude(x => x.Destination)
                    .Where(x => x.ProcedcureTage == null && x.ProcedcureUrl == null)
                    .OrderBy(x => x.ReminderDate)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .ToListAsync();


                    int recsCount = result.Count();
                    var pager = new Pager(recsCount, pg, pageSize);

                    var data = result.Skip(recSkip).Take(pager.PageSize).ToList();

                    ViewBag.Pager = pager;

                    return View(nameof(Index), data);
                }
            }
            else
            {
                ViewBag.Term = term;
                const int pageSize = 5;
                if (pg < 1)
                    pg = 1;

                var userId = userManager.GetUserId(HttpContext.User);

                ApplicationUser user = userManager.FindByIdAsync(userId).Result;



                int recSkip = (pg - 1) * pageSize;

                if (User.HasClaim(x => x.Type == "Officer"))
                {
                    var result = await context.FilesInfo
                    .Include(x => x.FileInfoSoruce)
                    .ThenInclude(x => x.FileSource)
                    .Include(x => x.FileInfoOfficers)
                    .ThenInclude(x => x.Officer)
                    .ThenInclude(x => x.Destination)
                    .Where(x => x.FileInfoOfficers.Select(x => x.OfficerId).Contains(user.Officer.Id))
                    .Where(x => x.ProcedcureTage == null && x.ProcedcureUrl == null)
                    .Where(
                        f => f.AboutTag.Contains(term) ||
                        f.ProcedcureTage.Contains(term) ||
                        f.Const.Contains(term) ||
                        f.FileInfoOfficers.Any(x => x.Officer.Name.Contains(term)) ||
                        f.FileInfoOfficers.Any(x => x.Officer.Destination.Name.Contains(term)) ||
                        f.FileInfoSoruce.Any(x => x.FileSource.Name.Contains(term))
                    )
                    .OrderByDescending(x => x.Date)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .ToListAsync();

                    int recsCount = result.Count();
                    var pager = new Pager(recsCount, pg, pageSize);

                    var data = result.Skip(recSkip).Take(pager.PageSize).ToList();

                    ViewBag.Pager = pager;

                    return View(nameof(Index), data);
                }
                else if (User.HasClaim(x => x.Type == "HeadDepartment"))
                {
                    var result = await context.FilesInfo
                    .Include(x => x.FileInfoSoruce)
                    .ThenInclude(x => x.FileSource)
                    .Include(x => x.FileInfoOfficers)
                    .ThenInclude(x => x.Officer)
                    .ThenInclude(x => x.Destination)
                    .Where(x => x.FileInfoOfficers.Select(x => x.Officer.Destination.Id).Contains(user.Department.Id))
                    .Where(x => x.ProcedcureTage == null && x.ProcedcureUrl == null)
                    .Where(
                        f => f.AboutTag.Contains(term) ||
                        f.ProcedcureTage.Contains(term) ||
                        f.Const.Contains(term) ||
                        f.FileInfoOfficers.Any(x => x.Officer.Name.Contains(term)) ||
                        f.FileInfoOfficers.Any(x => x.Officer.Destination.Name.Contains(term)) ||
                        f.FileInfoSoruce.Any(x => x.FileSource.Name.Contains(term))
                    )
                    .OrderByDescending(x => x.Date)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .ToListAsync();

                    int recsCount = result.Count();
                    var pager = new Pager(recsCount, pg, pageSize);

                    var data = result.Skip(recSkip).Take(pager.PageSize).ToList();

                    ViewBag.Pager = pager;

                    return View(nameof(Index), data);
                }
                else
                {
                    var result = await context.FilesInfo
                    .Include(x => x.FileInfoSoruce)
                    .ThenInclude(x => x.FileSource)
                    .Include(x => x.FileInfoOfficers)
                    .ThenInclude(x => x.Officer)
                    .ThenInclude(x => x.Destination)
                    .Where(x => x.ProcedcureTage == null && x.ProcedcureUrl == null)
                    .Where(
                        f => f.AboutTag.Contains(term) ||
                        f.ProcedcureTage.Contains(term) ||
                        f.Const.Contains(term) ||
                        f.FileInfoOfficers.Any(x => x.Officer.Name.Contains(term)) ||
                        f.FileInfoOfficers.Any(x => x.Officer.Destination.Name.Contains(term)) ||
                        f.FileInfoSoruce.Any(x => x.FileSource.Name.Contains(term))
                    )
                    .OrderByDescending(x => x.Date)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .ToListAsync();

                    int recsCount = result.Count();
                    var pager = new Pager(recsCount, pg, pageSize);

                    var data = result.Skip(recSkip).Take(pager.PageSize).ToList();

                    ViewBag.Pager = pager;

                    return View(nameof(Index), data);
                }
            }
        }

        [HttpGet]
        [Authorize(Policy = "MigratePolicy")]
        public async Task<ActionResult> EditModal(int id)
        {
            FileEditViewModel model = new FileEditViewModel();
            List<int> officerIds = new List<int>();
            List<int> depIds = new List<int>();
            var file = await context.FilesInfo
                .Include(x => x.FileInfoOfficers)
                .ThenInclude(x => x.Officer)
                .ThenInclude(x => x.Destination)
                .FirstOrDefaultAsync(x => x.Id == id);


            file.FileInfoOfficers.ToList()
            .ForEach(result => depIds.Add(result.Officer.Destination.Id));

            file.FileInfoOfficers.ToList()
            .ForEach(result => officerIds.Add(result.Officer.Id));


            model.drpOfficers = await context.Officers.Where(x => depIds.Contains(x.DestinationId))
                   .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
                   .ToListAsync();

            model.OfficerId = officerIds.ToArray();

            return PartialView("_EditModal", model);

        }

        [HttpPost]
        [Authorize(Policy = "MigratePolicy")]
        public async Task<ActionResult> EditModal(FileEditViewModel model)
        {
            List<FileInfoOfficers> fileInfoOfficers = new List<FileInfoOfficers>();
            Domain.Entites.FileInfo file = new Domain.Entites.FileInfo();

            file = await context.FilesInfo.Include(x => x.FileInfoOfficers).FirstOrDefaultAsync(x => x.Id == model.Id);

            file.FileInfoOfficers.ToList().ForEach(result => fileInfoOfficers.Add(result));
            context.FileInfoOfficers.RemoveRange(fileInfoOfficers);
            await context.SaveChangesAsync();

            if (model.OfficerId.Length > 0)
            {
                fileInfoOfficers = new List<FileInfoOfficers>();

                foreach (var item in model.OfficerId)
                {
                    fileInfoOfficers.Add(new FileInfoOfficers
                    { OfficerId = item, FileInfoId = model.Id });
                }
                file.FileInfoOfficers = fileInfoOfficers;
            }

            context.FilesInfo.Attach(file);
            context.Entry(file).Property(x => x.OfficerId).IsModified = true;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
