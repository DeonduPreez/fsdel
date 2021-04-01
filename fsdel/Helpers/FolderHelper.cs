using System;
using System.IO;
using System.Linq;
using fsdel.Models;

namespace fsdel.Helpers
{
    public static class FolderHelper
    {
        public static string GetValidFolderFromArg(string arg, string cwText)
        {
            var directory = arg;
            if (directory[0].Equals('.'))
            {
                directory = Directory.GetCurrentDirectory() + directory[1..];
            }

            if (Directory.Exists(directory))
            {
                return directory;
            }

            Console.Write(cwText);
            directory = GetValidFolder(cwText);

            return directory;
        }

        public static string GetValidFolder(string cwText)
        {
            Console.Write(cwText);
            var directory = Console.ReadLine();
            if (directory![0].Equals('.'))
            {
                directory = Directory.GetCurrentDirectory() + directory[1..];
            }

            while (!Directory.Exists(directory))
            {
                Console.Write("Invalid folder. ");
                Console.Write(cwText);
                directory = Console.ReadLine();
            }

            return directory;
        }

        public static FolderStructure BuildFolderStructure(string directory)
        {
            if (directory[^1] == '\\')
            {
                directory = directory[..^1];
            }

            var subDirStrings = Directory.GetDirectories(directory);
            var subDirs = new FolderStructure[subDirStrings.Length];
            for (var i = 0; i < subDirStrings.Length; i++)
            {
                var subDir = subDirStrings[i];
                subDirs[i] = BuildFolderStructure(subDir);
            }
            
            var folderStructure = new FolderStructure()
            {
                DirectoryPath = directory,
                DirectoryName = directory[(directory.LastIndexOf(@"\", StringComparison.Ordinal) + 1)..],
                Files = Directory.GetFiles(directory).Select(file => file[(file.LastIndexOf(@"\", StringComparison.Ordinal) + 1)..]).ToArray(),
                SubDirectories = subDirs
            };

            return folderStructure;
        }

        public static void DeleteByFolderStructure(string folderToDeleteFrom, FolderStructure folderStructure)
        {
            foreach (var file in folderStructure.Files)
            {
                var filePath = Path.Combine(folderToDeleteFrom, file);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            foreach (var subDirectory in folderStructure.SubDirectories)
            {
                DeleteByFolderStructure(Path.Combine(folderToDeleteFrom, subDirectory.DirectoryName), subDirectory);
            }

            if (FolderIsEmpty(folderToDeleteFrom))
            {
                Directory.Delete(folderToDeleteFrom);
            }
        }

        private static bool FolderIsEmpty(string directory)
        {
            return Directory.GetFileSystemEntries(directory).Length == 0;
        }
    }
}