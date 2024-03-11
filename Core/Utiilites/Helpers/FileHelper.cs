using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utiilites.Helpers
{
    public static class FileHelper
    {
        static string _basePath = Directory.GetCurrentDirectory() + "/wwwroot/";
        static string _imageFolder = "images/";
        static string _fullPath = _basePath + _imageFolder;

        public static string Add(IFormFile file)
        {
            CreateDirectory(_fullPath);

            var fileExtension = Path.GetExtension(file.FileName);
            CheckImage(fileExtension);

            var imagePath = _imageFolder + Guid.NewGuid().ToString() + fileExtension;

            CreateFile(file, _basePath + imagePath);

            return imagePath;
        }

        public static void Delete(string filePath)
        {
            File.Delete(_basePath + filePath);
        }

        public static string Update(IFormFile file, string oldFilePath)
        {
            Delete(oldFilePath);
            return Add(file);
        }

        private static void CheckImage(string extension)
        {
            var extensions = new List<string> { ".jpg", ".png", "jpeg" };

            //if (!extensions.Contains(extension))
                //throw new FileHelperCustomException(Messages.UnsupportedFileType);
                
        }

        private static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }

        private static void CreateFile(IFormFile file, string path)
        {
            using (FileStream fileStream = File.Create(path))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
        }
    }
}
