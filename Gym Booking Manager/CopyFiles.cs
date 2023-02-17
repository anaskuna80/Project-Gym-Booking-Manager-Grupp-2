using System;
using System.IO;

public static class CsvFileManager
{
    public static void CopyCsvFilesToStorageFolder()
    {
        // Get the path of the storage folder
        string storagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "storage");

        // Check if CSV files exist in the Gym Booking Manager\bin\Debug\net6.0 folder
        string gymBookingManagerPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..");
        string debugPath = Path.Combine(gymBookingManagerPath, "bin", "Debug", "net6.0","GymDB","storage");
        string[] csvFileNames = new string[] { "calender.csv", "customer.csv", "groupactivities.csv", "Largeequipment.csv", "PersonalTrainer.csv", "space.csv", "sportsequipment.csv", "staff.csv" };
        bool allFilesExist = true;
        foreach (string csvFileName in csvFileNames)
        {
            string csvFilePath = Path.Combine(debugPath, csvFileName);
            if (!File.Exists(csvFilePath))
            {
                Console.WriteLine($"CSV file {csvFileName} does not exist in {debugPath} folder. Copying.....");
                allFilesExist = false;
            }
        }

        // Copy CSV files to the Gym Booking Manager\bin\Debug\net6.0 folder from storage folder if they do not exist
        if (!allFilesExist)
        {
            foreach (string csvFileName in csvFileNames)
            {
                string storageFilePath = Path.Combine(storagePath, csvFileName);
                string destFile = Path.Combine(debugPath, csvFileName);
                File.Copy(storageFilePath, destFile, true);
            }
        }

        // Copy CSV files to the storage folder
        foreach (string csvFileName in csvFileNames)
        {
            string debugFilePath = Path.Combine(debugPath, csvFileName);
            string destFile = Path.Combine(storagePath, csvFileName);
            File.Copy(debugFilePath, destFile, true);
        }
    }
}
