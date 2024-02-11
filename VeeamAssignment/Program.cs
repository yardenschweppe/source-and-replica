using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        string sourceFolder = args[0];
        string replicaFolder = args[1];
        int interval = int.Parse(args[2]);
        string logFile = args[3];

        while (true)
        {
            // Create a list to get the files that exist in the source folder
            string[] sourceFiles = Directory.GetFiles(sourceFolder);

            // Compare files in source and replica folders to avoid duplicate
            foreach (string file in sourceFiles)
            {
                string fileName = Path.GetFileName(file);
                string replicaFile = Path.Combine(replicaFolder, fileName);

                // Check if the file exists in replica folder
                if (!File.Exists(replicaFile))
                {
                    // If the file not exists in replica folder, copy file from source to replica and log the operation to txt file(Log function)
                    File.Copy(file, replicaFile);
                    Log("Copied file " + fileName + " to replica folder", logFile);
                }
                else
                {
                    // If file exists, compare file sizes
                    FileInfo sourceFileInfo = new FileInfo(file);
                    FileInfo replicaFileInfo = new FileInfo(replicaFile);

                    if (sourceFileInfo.Length != replicaFileInfo.Length)
                    {
                        // If file sizes are different, copy file from source to replica and log the operation
                        File.Copy(file, replicaFile, true);
                        Log("Copied file " + fileName + " to replica folder", logFile);
                    }
                }
            }

            // Get a list of files in replica folder
            string[] replicaFiles = Directory.GetFiles(replicaFolder);

            // Compare files in replica and source folders
            foreach (string file in replicaFiles)
            {
                string fileName = Path.GetFileName(file);
                string sourceFile = Path.Combine(sourceFolder, fileName);

                // Check if the file exists in source folder
                if (!File.Exists(sourceFile))
                {
                    // If it is not exists in source folder, delete the file from replica folder and log the operation
                    File.Delete(file);
                    Log("Deleted file " + fileName + " from replica folder", logFile);
                }
            }

            // Sleep for the specified interval before next synchronization
            Thread.Sleep(interval * 1000);
        }
    }

    static void Log(string message, string logFile)
    {
        // Write message to log file
        using (StreamWriter writer = new StreamWriter(logFile, true))
        {
            writer.WriteLine(DateTime.Now + ": " + message);
        }

        // Print message to console
        Console.WriteLine(message);
    }
}