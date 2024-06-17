using System;
using System.IO.Compression;
namespace BackupZip;
public static class FileZip
{
    static Form1 mainForm = new Form1();//creo reference del Form1.cs 
    public static string SelectPath()//funzione per aprire finestra dialogo seleziona cartella
    {
        string selectedPath="";
        using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
        {
            folderBrowserDialog.Description = "Select the folder you want to use";
            folderBrowserDialog.ShowNewFolderButton = true;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                selectedPath = folderBrowserDialog.SelectedPath;
                //MessageBox.Show("Selected Path: " + selectedPath, "Folder Path");
            }
        }
        return selectedPath;
    }
    public static string BackupSave(string @sourceFolder,string @localZipFilePath,string serverZipFolderPath)//funzione per creare file zip
    {
        DateTime now = DateTime.Now;
        string status="";
        string zipFileName="\\AW129-LV2021-"+now.ToString("dd-MM-yyy")+".zip";
        string destinationZipFilePath=localZipFilePath+zipFileName;
        string serverZipFilePath=serverZipFolderPath+zipFileName;
        try
            {
                //mainForm.SetLabelTextByName("compressione in corso", "BackupSave");
                // Create ZIP file from source folder
                ZipFile.CreateFromDirectory(sourceFolder, destinationZipFilePath);
                
                status=$"Folder '{sourceFolder}' has been successfully zipped to '{destinationZipFilePath}'";
                status=status + "\n" + CopyFile(destinationZipFilePath,serverZipFilePath);
            }
            catch (Exception ex)
            {
                status=$"An error occurred: {ex.Message}";
            }
        return status;
    }
    public static string CopyFile(string sourceFile,string destinationFile)
    {
         string status="";
        try
            {
                // Ensure the destination directory exists
                string destinationDirectory = Path.GetDirectoryName(destinationFile);
                if (Directory.Exists(destinationDirectory))
                {
                    //Directory.CreateDirectory(destinationDirectory);
                    // Copy the file
                    
                }
                File.Copy(sourceFile, destinationFile, true); // The third parameter 'true' allows overwriting the destination file if it already exists
                status="File copied successfully.";
            }
        catch (IOException ioEx)
            {
                status="An I/O error occurred: " + ioEx.Message;
            }
        catch (UnauthorizedAccessException uaEx)
            {
                status="You do not have permission to access this file: " + uaEx.Message;
            }
        catch (Exception ex)
            {
                status="An error occurred: " + ex.Message;
            }
        return status;
    }
}    
  