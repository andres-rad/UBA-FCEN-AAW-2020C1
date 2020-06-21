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
        public static void PersistFiles(IFormFile[] files)
        {
            var uploads = "c:\\tmpTP";
            System.IO.Directory.CreateDirectory(uploads);
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var filePath = Path.Combine(uploads, file.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyToAsync(fileStream);
                    }
                }
            }
        }
    }
}
