using Domain.Entites;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UI.ViewModels
{
    public class OfficerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public IEnumerable<FileDestination> Department { get; set; }
    }
}
