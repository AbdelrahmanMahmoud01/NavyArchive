namespace Domain.Entites
{
    public class FileInfoOfficers
    {
        public int FileInfoId { get; set; }
        public virtual FileInfo FileInfo { get; set; }
        public int OfficerId { get; set; }
        public virtual Officer Officer { get; set; }
    }
}
