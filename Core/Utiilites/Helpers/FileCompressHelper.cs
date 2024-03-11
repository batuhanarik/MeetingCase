using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utiilites.Helpers
{
    public static class DocumentHelper
    {

        public static string CompressDocuments(IFormFile[] files)
        {
            var zipFileName = Guid.NewGuid().ToString() + ".zip";
            var zipFilePath = Path.Combine("wwwroot\\documents", zipFileName);

            using (var zipArchive = ZipFile.Open(zipFilePath, ZipArchiveMode.Create))
            {
                foreach (var file in files)
                {
                    var entry = zipArchive.CreateEntry(file.FileName,CompressionLevel.Optimal);

                    using (var entryStream = entry.Open())
                    using (var documentStream = file.OpenReadStream())
                    {
                        documentStream.CopyToAsync(entryStream);
                    }
                }
            }
            return zipFilePath;
        }
    }
}
