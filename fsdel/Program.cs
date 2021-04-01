using System;
using fsdel.Helpers;

namespace fsdel
{
    class Program
    {
        private const string structureFolderText = "Please specify a structure folder: ";
        private const string folderToDeleteFromText = "Please specify a folder to delete from: ";
        
        static void Main(string[] args)
        {
            var structureFolder = string.Empty;
            var folderToDeleteFrom = string.Empty;
            if (args.Length > 1)
            {
                structureFolder = FolderHelper.GetValidFolderFromArg(args[0], structureFolderText);
                folderToDeleteFrom = FolderHelper.GetValidFolderFromArg(args[1], folderToDeleteFromText);
            }
            else if (args.Length > 0)
            {
                structureFolder = FolderHelper.GetValidFolderFromArg(args[0], structureFolderText);
                folderToDeleteFrom = FolderHelper.GetValidFolder(folderToDeleteFromText);
            }
            else
            {
                structureFolder = FolderHelper.GetValidFolder(structureFolderText);
                folderToDeleteFrom = FolderHelper.GetValidFolder(folderToDeleteFromText);
            }

            Console.WriteLine($"structureFolder: {structureFolder}");
            Console.WriteLine($"folderToDeleteFrom: {folderToDeleteFrom}");

            var folderStructure = FolderHelper.BuildFolderStructure(structureFolder);
            FolderHelper.DeleteByFolderStructure(folderToDeleteFrom, folderStructure);

            Console.Read();
        }
    }
}