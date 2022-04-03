using Domain.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UI.Validations;

namespace UI.ViewModels
{
    public class FileEditViewModel 
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "من فضلك أملاء الحقل")]
        [MaxLength(25)]
        public string Const { get; set; }

        [Required(ErrorMessage = "من فضلك أملاء الحقل")]
        public int[] SourceId { get; set; }
        public virtual List<FileSource> Source { get; set; }

        [AllowedExtensions(new string[] { ".jpg", ".png", ".pdf" })]
        [Display(Name = @"أختر ملف")]
        public IFormFile AboutUrl { get; set; }

        [Required(ErrorMessage = "من فضلك أملاء الحقل")]
        [MaxLength(25)]

        public string AboutTag { get; set; }

        [Required(ErrorMessage = "من فضلك أملاء الحقل")]
        public int[] DepartmentId { get; set; }
        public virtual List<FileDestination> Department { get; set; }

        [Required(ErrorMessage = "من فضلك أملاء الحقل")]
        public int[] OfficerId { get; set; }
        public virtual List<Officer> Officer { get; set; }

        [AllowedExtensions(new string[] { ".jpg", ".png", ".pdf" })]
        [Display(Name = @"أختر ملف")]
        public IFormFile ProcedcureUrl { get; set; }
        [MaxLength(25)]
        public string ProcedcureTage { get; set; }
        public DateTime Date { get; private set; } = DateTime.Now;

        [Required(ErrorMessage = "من فضلك أملاء الحقل")]
        //[CheckDate()]
        public DateTime ReminderDate { get; set; }
        public string Note { get; set; }

        public List<SelectListItem> drpSoruces { get; set; }
        public string ExistingFilePath { get; set; }
        public string ExistingProcPath { get; set; }
        public List<SelectListItem> drpDepartments { get; set; }
        public List<SelectListItem> drpOfficers { get; set; }
        public bool IsSelected { get; set; }

    }
}
