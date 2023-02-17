using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


public static class CsvFileManager
{
    public static void CopyCsvFilesToStorageFolder()
    {
        // Get the path of the project folder
        string projectPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        // Get the path of the storage folder
        string storagePath = Path.Combine(projectPath, "bin", "Debug", "net6.0", "GymDB", "storage");

        // Get all CSV files in the project folder
        string[] csvFiles = Directory.GetFiles(projectPath, "*.csv");

        // Copy all CSV files to the storage folder
        foreach (string csvFile in csvFiles)
        {
            string fileName = Path.GetFileName(csvFile);
            string destFile = Path.Combine(storagePath, fileName);
            File.Copy(csvFile, destFile, true);
        }
    }
}





