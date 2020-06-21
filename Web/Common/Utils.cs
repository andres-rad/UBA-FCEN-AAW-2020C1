using Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Common
{
    public class Utils
    {
        public static List<FilePath> PersistFiles(IFormFile[] files, string basePath)
        {
            List<FilePath> filePaths = new List<FilePath>();
            var uploads = basePath + "\\wwwroot\\img";
            System.IO.Directory.CreateDirectory(uploads);
            if(files!= null)
            { 
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var filePath = Path.Combine(uploads, file.FileName);
                    filePaths.Add(new FilePath(0, file.FileName));
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.OpenReadStream().Seek(0, SeekOrigin.Begin);
                        file.CopyTo(fileStream);
                        fileStream.Close();
                    }
                }
            }
            }
            return filePaths;
        }
    }
}
