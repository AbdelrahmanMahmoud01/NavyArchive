using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI.ViewModels
{
    public class ModalEditViewModel
    {
        [Required(ErrorMessage = "من فضلك أملاء الحقل")]
        public int[] SourceId { get; set; }
    }
}
