using System.Collections.Generic;

namespace Domain.Entites
{
    public class Officer : BaseEntity
    {
        public string Name { get; set; }
        public virtual FileDestination Destination { get; set; }
        public int DestinationId { get; set; }
        public virtual IList<FileInfoOfficers> FileInfoOfficers { get; set; } = new List<FileInfoOfficers>();
    }
}
