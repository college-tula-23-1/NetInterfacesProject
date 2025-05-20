using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFileSystemProject
{
    static class Examples
    {
        public static void DriveInfoExample()
        {
            var drives = DriveInfo.GetDrives();

            foreach (var drive in drives)
            {
                Console.WriteLine($"Drive: {drive.Name}");
                Console.WriteLine($"Type: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Label: {drive.VolumeLabel}");
                    Console.WriteLine($"Format: {drive.DriveFormat}");
                    Console.WriteLine($"Total memory: {drive.TotalSize / 1024 / 1024}");
                    Console.WriteLine($"Free memory: {drive.TotalFreeSpace / 1024 / 1024}");
                }
                Console.WriteLine();
            }
        }

        public static void DirectoryExample()
        {
            var currentDirPath = Directory.GetCurrentDirectory();
            var currentDir = new DirectoryInfo(currentDirPath);

            var root = currentDir.Root;

            if (root is not null)
            {
                var dirs = root.GetDirectories();
                //var dirs = Directory.GetDirectories(root.Name);
                foreach (var dir in dirs)
                    Console.WriteLine($"{dir.Name} <DIR>");

                var files = root.GetFiles();
                foreach (var file in files)
                    Console.WriteLine($"{file.Name} {file.Extension} {file.Length}");


                string dirNewPath = root.Name + "Maxim Directory";
                //Directory.CreateDirectory(dirNewPath);
                //Directory.Delete(dirNewPath, true);

                DirectoryInfo dirNew = new(dirNewPath);
                //dirNew.Create();
                dirNew.Delete(true);
            }
        }

        public static void FileInfoExample()
        {
            DirectoryInfo maxDir = new(
                new DirectoryInfo(Directory.GetCurrentDirectory()).Root + "Maxim Directory"
            );

            if (!maxDir.Exists)
                maxDir.Create();

            File.Create(maxDir.FullName + "/file01.txt");

            FileInfo file = new(maxDir.FullName + "/file02.txt");
            file.Create();

        }
    }
}
