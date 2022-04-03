using Application.Contracts;
using Application.Features.FileDest.Queries;
using Application.Features.FileSrc.Queries.GetSrcList;
using Application.Features.Pagintaion;
using Domain.Entites;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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
    public class FileController : Controller
    {
        private readonly IFileRepository repository;
        private readonly DataContext context;
        private readonly IWebHostEnvironment webHost;
        private readonly IAsyncReposiotry<FileSource> sourceRepo;
        private readonly IAsyncReposiotry<FileDestination> depRepo;
        private readonly IOfficerReposiotry officerReposiotry;
        private readonly IMediator mediator;
        private readonly UserManager<ApplicationUser> userManager;
        private List<string> _allowedExtenstions = new List<string> { ".jpg", ".png",".pdf" };

        public FileController(IFileRepository repository, 
            DataContext context,
            IWebHostEnvironment webHost,
            IAsyncReposiotry<FileSource> sourceRepo, IAsyncReposiotry<FileDestination> depRepo,
            IOfficerReposiotry officerReposiotry,
            IMediator mediator,
            UserManager<ApplicationUser> userManager) 
        {
            this.repository = repository;
            this.context = context;
            this.webHost = webHost;
            this.sourceRepo = sourceRepo;
            this.depRepo = depRepo;
            this.officerReposiotry = officerReposiotry;
            this.mediator = mediator;
            this.userManager = userManager;
        }
        // GET: FileController
        [Authorize(Policy = "ReadPolicy")]
        public async Task<ActionResult> Index(int pg = 1)
        {
            //var dtos = await mediator.Send(new FileInfoQuery());
            //return View(dtos);

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
                .OrderByDescending(x => x.Date)
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
                .Where(x => x.FileInfoOfficers.Select(x=>x.Officer.Destination.Id).Contains(user.Department.Id))
                .OrderByDescending(x => x.Date)
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
                .OrderByDescending(x => x.Date)
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

        // GET: FileController/Details/5
        [Authorize(Policy = "DetailsPolicy")]
        public async Task<ActionResult> Details(int id)
        {
            Domain.Entites.FileInfo query = await context.FilesInfo
                .Include(x => x.FileInfoSoruce)
                .ThenInclude(x => x.FileSource)
                .Include(x => x.FileInfoOfficers)
                .ThenInclude(x => x.Officer)
                .ThenInclude(x => x.Destination)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderByDescending(x => x.Date)
                .FirstOrDefaultAsync(x => x.Id == id);

            FileDetailsViewModel model = new FileDetailsViewModel
            {
                AboutTag = query.AboutTag,
                AboutUrl = query.AboutUrl,
                Const = query.Const,
                Date = query.Date,
                DepartmentName = query.FileInfoOfficers.Select(x => x.Officer.Destination.Name),
                OfficerName = query.FileInfoOfficers.Select(x => x.Officer.Name),
                SoruceName = query.FileInfoSoruce.Select(x => x.FileSource.Name),
                Note = query.Note,
                ReminderDate = query.ReminderDate,
                ProcedcureTage = query.ProcedcureTage,
                ProcedcureUrl = query.ProcedcureUrl,
            };
            return View(model);

        }

        // GET: FileController/Create
        [Authorize(Policy = "CreatePolicy")]
        public async Task<ActionResult> Create(int fileId = 0, bool IsSuccess = false)
        {
            ViewBag.Source = new SelectList(await mediator.Send(new GetSrcListQuery()), "Id", "Name");
            ViewBag.Department = new SelectList(await mediator.Send(new GetFileDestQuery()), "Id", "Name");
            ViewBag.IsSuccess = IsSuccess;
            ViewBag.fileId = fileId;


            return View();
        }

        public async Task<JsonResult> LoadOfficers(int[] cid)
        {
            //return (Json(await mediator.Send(new GetOfficersInDepartment() { Id = cid })));


            var officers = await context.Officers
                .Where(f => cid.Contains(f.DestinationId))
                .Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = f.Name
                }).ToListAsync();

            return Json(officers);
        }

        // POST: FileController/Create
        [HttpPost]
        [Authorize(Policy = "CreatePolicy")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(/*CreateFileCommand*/ FileViewModel model,
            int fileId = 0, bool IsSuccess = false)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    Domain.Entites.FileInfo fileInfo = new Domain.Entites.FileInfo();
                    List<FileInfoOfficers> fileInfoOfficers = new List<FileInfoOfficers>();
                    List<FileInfoSoruce> fileInfoSoruces = new List<FileInfoSoruce>();
                    fileInfo.AboutUrl = ProcessUploadedFile(model.AboutUrl);
                    fileInfo.ProcedcureUrl = ProcessUploadedFile(model.ProcedcureUrl);
                    fileInfo.ProcedcureTage = model.ProcedcureTage;
                    fileInfo.AboutTag = model.AboutTag;
                    fileInfo.Const = model.Const;
                    fileInfo.Note = model.Note;
                    fileInfo.ReminderDate = model.ReminderDate;

                    if (model.OfficerId.Length > 0)
                    {
                        foreach (var item in model.OfficerId)
                        {
                            fileInfoOfficers.Add(new FileInfoOfficers
                            { OfficerId = item, FileInfoId = model.Id });
                        }
                        fileInfo.FileInfoOfficers= fileInfoOfficers;
                    }

                    if (model.SourceId.Length > 0)
                    {
                        foreach (var item in model.SourceId)
                        {
                            fileInfoSoruces.Add(new FileInfoSoruce
                            { FileSourceId = item, FileInfoId = model.Id });
                        }
                        fileInfo.FileInfoSoruce = fileInfoSoruces;
                    }
                    ViewBag.IsSuccess = IsSuccess;
                    ViewBag.fileId = fileId;
                    await context.FilesInfo.AddAsync(fileInfo);
                    await context.SaveChangesAsync();
                    return RedirectToAction("Create", new { IsSuccess = true, fileId = fileInfo.Id });

                }

                ViewBag.Source = new SelectList(await mediator.Send(new GetSrcListQuery()), "Id", "Name");
                ViewBag.Department = new SelectList(await mediator.Send(new GetFileDestQuery()), "Id", "Name");
                ViewBag.Officer = new SelectList(await context.Officers
                .Where(f => model.DepartmentId.Contains(f.DestinationId))
                .Select(f => new Officer
                {
                    Id = f.Id,
                    Name = f.Name
                }).ToListAsync(), "Id", "Name");
                ViewBag.IsSuccess = false;

                return View(model);
            }
            catch
            {
                return View();
            }
        }

        private string ProcessUploadedFile(IFormFile model)
        {
            string uniqueFileName = null;
            if (model != null)
            {
                //foreach (var item in model)
                //{
                if (_allowedExtenstions.Contains(Path.GetExtension(model.FileName).ToLower()))
                {
                    string uploadsFolder = Path.Combine(webHost.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            model.CopyTo(fileStream);
                        }
                }
                //}
            }

            return uniqueFileName;
        }

        // GET: FileController/Edit/5
        [Authorize(Policy = "EditPolicy")]
        public async Task<ActionResult> Edit(int id)
        {

            FileEditViewModel model = new FileEditViewModel();
            List<int> srcIds = new List<int>();
            List<int> officerIds = new List<int>();
            List<int> depIds = new List<int>();


            var file = await context.FilesInfo
                .Include(x => x.FileInfoSoruce)
                .ThenInclude(x => x.FileSource)
                .Include(x => x.FileInfoOfficers)
                .ThenInclude(x => x.Officer)
                .ThenInclude(x => x.Destination)
                .AsSplitQuery()
                .OrderByDescending(x=>x.Date)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (file is null)
                return View("404");

            file.FileInfoSoruce.ToList()
                .ForEach(result => srcIds.Add(result.FileSource.Id));

           
            file.FileInfoOfficers.ToList()
                .ForEach(result => depIds.Add(result.Officer.Destination.Id));


            file.FileInfoOfficers.ToList()
            .ForEach(result => officerIds.Add(result.Officer.Id));

            


            model.ExistingFilePath = file.AboutUrl;
            model.ExistingProcPath = file.ProcedcureUrl;
            model.Const = file.Const;
            model.AboutTag = file.AboutTag;
            model.ProcedcureTage = file.ProcedcureTage;
            model.ReminderDate = file.ReminderDate;
            model.Note = file.Note;

            model.drpSoruces = await context.Sources
                .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
                .ToListAsync();

            model.drpDepartments = await context.Destinations
                .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
                .ToListAsync();

            model.drpOfficers = await context.Officers.Where(x=>depIds.Contains(x.DestinationId))
                   .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
                   .ToListAsync();
           


            model.SourceId = srcIds.ToArray();
            model.OfficerId = officerIds.ToArray();
            model.DepartmentId = depIds.ToArray();
            ViewBag.AboutUrl = file.AboutUrl;
            ViewBag.ProcedcureUrl = file.ProcedcureUrl;

            return View(model);
        }

        // POST: FileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "EditPolicy")]
        public async Task<ActionResult> Edit(FileEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<FileInfoOfficers> fileInfoOfficers = new List<FileInfoOfficers>();
                    List<FileInfoSoruce> fileInfoSoruces = new List<FileInfoSoruce>();
                    Domain.Entites.FileInfo file = await context.FilesInfo.FirstOrDefaultAsync(x => x.Id == model.Id);


                    //first find teacher subjects list and then remove all from db 
                    file = await context.FilesInfo.Include(x => x.FileInfoSoruce).FirstOrDefaultAsync(x => x.Id == model.Id);
                    file.FileInfoSoruce.ToList().ForEach(result => fileInfoSoruces.Add(result));
                    context.FileInfoSoruce.RemoveRange(fileInfoSoruces);
                    await context.SaveChangesAsync();

                    file = await context.FilesInfo.Include(x => x.FileInfoOfficers).FirstOrDefaultAsync(x => x.Id == model.Id);
                    file.FileInfoOfficers.ToList().ForEach(result => fileInfoOfficers.Add(result));
                    context.FileInfoOfficers.RemoveRange(fileInfoOfficers);
                    await context.SaveChangesAsync();


                    //Now update teacher details
                    if (model.SourceId.Length > 0)
                    {
                        fileInfoSoruces = new List<FileInfoSoruce>();

                        foreach (var item in model.SourceId)
                        {
                            fileInfoSoruces.Add(new FileInfoSoruce
                            { FileSourceId = item, FileInfoId = model.Id });
                        }
                        file.FileInfoSoruce = fileInfoSoruces;
                    }

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

                    if (model.AboutUrl != null)
                    {
                        if (model.ExistingFilePath != null)
                        {
                            string filePath = Path.Combine(webHost.WebRootPath,
                                "images", model.ExistingFilePath);
                            System.IO.File.Delete(filePath);
                        }
                        file.AboutUrl = ProcessUploadedFile(model.AboutUrl);
                    }


                    if (model.ProcedcureUrl != null)
                    {
                        if (model.ExistingProcPath != null)
                        {
                            string filePath = Path.Combine(webHost.WebRootPath,
                                "images", model.ExistingProcPath);
                            System.IO.File.Delete(filePath);
                        }
                        file.ProcedcureUrl = ProcessUploadedFile(model.ProcedcureUrl);
                    }

                    file.AboutTag = model.AboutTag;
                    file.Const = model.Const;
                    file.Note = model.Note;
                    file.ProcedcureTage = model.ProcedcureTage;
                    file.ReminderDate = model.ReminderDate;
                    var updatedFiles = context.FilesInfo.Attach(file);
                    updatedFiles.State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.IsSuccess = false;

                return View(model);
            }
            catch
            {
                return View();  
            }
        }



        // GET: FileController/Delete/5
        [Authorize(Policy = "DeletePolicy")]
        public async Task<ActionResult> Delete(int id)
        {
            Domain.Entites.FileInfo query = await context.FilesInfo
            .Include(x => x.FileInfoSoruce)
            .ThenInclude(x => x.FileSource)
            .Include(x => x.FileInfoOfficers)
            .ThenInclude(x => x.Officer)
            .ThenInclude(x => x.Destination)
            .AsNoTracking()
            .AsSplitQuery()
            .OrderByDescending(x => x.Date)
            .FirstOrDefaultAsync(x => x.Id == id);

            FileDetailsViewModel model = new FileDetailsViewModel
            {
                AboutTag = query.AboutTag,
                AboutUrl = query.AboutUrl,
                Const = query.Const,
                Date = query.Date,
                DepartmentName = query.FileInfoOfficers.Select(x => x.Officer.Destination.Name),
                OfficerName = query.FileInfoOfficers.Select(x => x.Officer.Name),
                SoruceName = query.FileInfoSoruce.Select(x => x.FileSource.Name),
                Note = query.Note,
                ReminderDate = query.ReminderDate,
                ProcedcureTage = query.ProcedcureTage,
                ProcedcureUrl = query.ProcedcureUrl,
            };
            return View(model);
        }

        // POST: FileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "DeletePolicy")]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var file = await context.FilesInfo.FirstOrDefaultAsync(x => x.Id == id);

                if (file.AboutUrl != null || file.AboutUrl == string.Empty)
                {
                    string filePath = Path.Combine(webHost.WebRootPath,
                                "images", file.AboutUrl);
                    System.IO.File.Delete(filePath);
                }

                if (file.ProcedcureUrl != null || file.ProcedcureUrl == string.Empty)
                {
                    string filePath = Path.Combine(webHost.WebRootPath,
                                "images", file.ProcedcureUrl);
                    System.IO.File.Delete(filePath);
                }


                context.FilesInfo.Remove(file);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Policy = "SearchPolicy")]
        public async Task<ActionResult> Search(string term , int critera, int pg = 1)
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

            return PartialView("_EditModal",model);

        }

        [HttpPost]
        [Authorize(Policy = "MigratePolicy")]
        public async Task<ActionResult> EditModal(FileEditViewModel model)
        {
            if (model.OfficerId != null)
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
            return RedirectToAction(nameof(Index));
        }

    }
}
