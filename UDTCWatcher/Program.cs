using System;
using System.IO;
using System.Configuration;

namespace UDTCWatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ACPIX Watcher!");
            Program p = new Program();
            p.Start();
            Console.WriteLine("Press ESC to stop");
            do
            {
                while (!Console.KeyAvailable)
                {
                    // Do something
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        private void Start()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = ConfigurationManager.AppSettings["FolderWatch"];
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | 
                                   NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = "*.*";
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.EnableRaisingEvents = true;
        }

        private void OnCreated(object source, FileSystemEventArgs e)
        {
            FileInfo acspixFile = new FileInfo(e.FullPath);
            Console.WriteLine($"New ACSPIX {acspixFile.FullName}");
            // TODO DeCryptSinovoFile
            // TODO ProcessAcspix
            // TODO Remove File
        }
    }
}
