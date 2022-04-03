namespace Domain.Entites
{
    public class FileInfoSoruce
    {
        public int FileInfoId { get; set; }
        public virtual FileInfo FileInfo { get; set; }
        public int FileSourceId { get; set; }
        public virtual FileSource FileSource { get; set; }
    }
}
