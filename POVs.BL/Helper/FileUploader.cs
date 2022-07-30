using Microsoft.AspNetCore.Http;
using POVs.BL.Class;
using System;
using System.IO;

namespace POVs.BL.Helper
{
    public static class FileUploader
    {
        public static string GetFullPath(params string[] FolderName)
        {
            string FullPath = FolderName[0];
            for (var i = 1; i < FolderName.Length; i++)
            {
                if (FolderName[i] != null)
                {
                    FullPath = Path.Combine(FullPath, FolderName[i]);
                }
            }
            return FullPath;
        }
        public static string UploadFile(string FolderName, IFormFile File, out bool IsVal)
        {
            string FileName = string.Empty;
            try
            {
                IsVal = true;
                string FullPath = string.Empty;
                string FinalPath = string.Empty;

                // catch folder path
                FullPath = GetFullPath(Directory.GetCurrentDirectory(), Constant.WwwrootFilePath, FolderName);

                if (File != null)
                {
                    FileName = Guid.NewGuid() + Path.GetFileName(File.FileName);

                    //catch final path
                    FinalPath = GetFullPath(FullPath, FileName);

                    SaveFile(File, FinalPath, FileMode.Create);
                }
            }
            catch (Exception ex)
            {
                IsVal = false;
                return ex.Message;
            }
            return FileName;
        }
        public static void SaveFile(IFormFile File, string Path, FileMode Mode)
        {
            // save the files
            using (var Stream = new FileStream(Path, Mode))
            {
                File.CopyTo(Stream);
            }
        }

        public static bool RemoveFile(string FullPath)
        {
            try
            {
                if (File.Exists(FullPath))
                {
                    File.Delete(FullPath);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
