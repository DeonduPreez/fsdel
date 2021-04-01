namespace fsdel.Models
{
    public class FolderStructure
    {
        public string DirectoryName { get; set; }
        public string[] Files { get; set; }
        public FolderStructure[] SubDirectories { get; set; }
    }
}