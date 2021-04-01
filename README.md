# fsdel - Folder Structure Delete

Deletes files and folders in the exact same structure as specified.

This is useful when you extracted a zip file into the wrong folder and want to remove those files without removing them manually

Usage
-----

```
fsdel arg1 arg2 

arg1 - FolderStructure
arg2 - FolderToDeleteFrom

e.g.
    fsdel C:\FsFolder C:\MergedFolder
```

1. Removes all files that are specified in the folder structure from arg1
2. Recursively runs for every subdirectory specified in the folder structure from arg1
3. Removes the folder if it is empty and is specified in the folder structure from arg1


This tool was created because I accidentally extracted a zip file into the wrong folder. It merged into all subdirectories and I'm too lazy to delete every file manually