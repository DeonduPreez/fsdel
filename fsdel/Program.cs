using System;
using fsdel.Helpers;

namespace fsdel
{
    class Program
    {
        private const string StructureFolderText = "Please specify a structure folder: ";
        private const string FolderToDeleteFromText = "Please specify a folder to delete from: ";

        private static void Main(string[] args)
        {
            string structureFolder;
            string folderToDeleteFrom;
            switch (args.Length)
            {
                case > 1:
                    structureFolder = FolderHelper.GetValidFolderFromArg(args[0], StructureFolderText);
                    folderToDeleteFrom = FolderHelper.GetValidFolderFromArg(args[1], FolderToDeleteFromText);
                    break;
                case > 0:
                    structureFolder = FolderHelper.GetValidFolderFromArg(args[0], StructureFolderText);
                    folderToDeleteFrom = FolderHelper.GetValidFolder(FolderToDeleteFromText);
                    break;
                default:
                    structureFolder = FolderHelper.GetValidFolder(StructureFolderText);
                    folderToDeleteFrom = FolderHelper.GetValidFolder(FolderToDeleteFromText);
                    break;
            }

            var folderStructure = FolderHelper.BuildFolderStructure(structureFolder);
            FolderHelper.DeleteByFolderStructure(folderToDeleteFrom, folderStructure);

            Console.WriteLine("Success");
        }
    }
}