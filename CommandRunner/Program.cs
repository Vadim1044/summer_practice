using System;
using System.IO;
using System.Reflection;
using CommandLib;

namespace CommandRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory;
            string searchPattern;

            if (args.Length < 2)
            {
                Console.Write("Директория: ");
                directory = Console.ReadLine();

                Console.Write("Расширение файлов (*.txt и тд): ");
                searchPattern = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(directory) || string.IsNullOrWhiteSpace(searchPattern))
                {
                    Console.WriteLine("Не указаны какие то параметры");
                    return;
                }
            }
            else
            {
                directory = args[0];
                searchPattern = args[1];
            }
            var assembly = Assembly.LoadFrom("FileSystemCommands.dll");

            var directorySizeCommandType = assembly.GetType("FileSystemCommands.DirectorySizeCommand");
            var directorySizeCommand = (ICommand)Activator.CreateInstance(directorySizeCommandType, directory);
            directorySizeCommand.Execute();

            var findFilesCommandType = assembly.GetType("FileSystemCommands.FindFilesCommand");
            var findFilesCommand = (ICommand)Activator.CreateInstance(findFilesCommandType, directory, searchPattern);
            findFilesCommand.Execute();
        }
    }
}