using Microsoft.Win32;
using System;

public class FileAssociation
{
    public static void RegisterFileAssociation(string fileExtension, string applicationPath)
    {
        string extKey = $@"HKEY_CLASSES_ROOT\{fileExtension}";
        string appKey = $@"HKEY_CLASSES_ROOT\MyFSCFile";

        // Check if the extension key already exists
        if (Registry.GetValue(extKey, "", null) == null)
        {
            // Create or update the file extension key
            Registry.SetValue(extKey, "", "MyFSCFile");
        }

        // Check if the application file type key already exists
        if (Registry.GetValue(appKey, "", null) == null)
        {
            // Create or update the associated application key
            Registry.SetValue(appKey, "", "FSC File Program");

            // Create the shell open command
            string command = $"\"{applicationPath}\" \"%1\"";
            Registry.SetValue($@"{appKey}\shell\open\command", "", command);
        }
        else
        {
            // Optional: Log or handle case where file association already exists
            Console.WriteLine("The file association is already registered.");
        }
    }
}