using System;
using System.IO;
using System.Linq;
using CommandLib;

namespace FileSystemCommands
{
    public class DirectorySizeCommand : ICommand
    {
        private readonly string _directoryPath;

        public DirectorySizeCommand(string directoryPath)
        {
            _directoryPath = directoryPath;
        }

        public void Execute()
        {
            long size = CalculateDirectorySize(_directoryPath);
            Console.Write($"Directory size:{size} bytes");
        }

        private long CalculateDirectorySize(string directory)
        {
            long size = 0;
            foreach (var file in Directory.GetFiles(directory))
            {
                size += new FileInfo(file).Length;
            }
            foreach (var subDir in Directory.GetDirectories(directory))
            {
                size += CalculateDirectorySize(subDir);
            }

            return size;
        }
    }

    public class FindFilesCommand : ICommand
    {
        private readonly string _directoryPath;
        private readonly string _searchPattern;
        public FindFilesCommand(string directoryPath, string searchPattern)
        {
            _directoryPath = directoryPath;
            _searchPattern = searchPattern;
        }

        public void Execute()
        {
            var files = Directory.GetFiles(_directoryPath, _searchPattern);
            Console.Write($"Found {files.Length} files");
            foreach (var file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }
    }
}