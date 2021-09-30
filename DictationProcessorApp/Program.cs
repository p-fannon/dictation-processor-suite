using System;
using System.IO;
using DictationProcessorLib;

namespace DictationProcessorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // iterate through subfolders of /mnt/uploads
            foreach (var subfolder in Directory.GetDirectories("/Users/fannonp/Documents/dotnet-core-mac-linux-getting-started/m4/demos/uploads")) 
            {
                var uploadProcessor = new UploadProcessor(subfolder);
                uploadProcessor.Process();
            }
        }
    }
}
