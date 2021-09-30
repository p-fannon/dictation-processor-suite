using System;
using System.IO;
using DictationProcessorLib;

namespace DictationProcessorSvc
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileSystemWatcher = new FileSystemWatcher("/Users/fannonp/Documents/dotnet-core-mac-linux-getting-started/m4/demos/uploads", "metadata.json");
            fileSystemWatcher.IncludeSubdirectories = true;
            while (true) 
            {
                var result = fileSystemWatcher.WaitForChanged(WatcherChangeTypes.Created);
                Console.WriteLine($"New Metadata file {result.Name}");
                var fullMetadataFilePath = Path.Combine("/Users/fannonp/Documents/dotnet-core-mac-linux-getting-started/m4/demos/uploads", result.Name);
                var subfolder = Path.GetDirectoryName(fullMetadataFilePath);
                var processor = new UploadProcessor(subfolder);
                processor.Process();
            }
            
        }
    }
}
