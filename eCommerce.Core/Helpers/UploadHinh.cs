using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Helpers
{
    public class UploadHinh
    {
        public static string UploadImage(IFormFile Hinh, string folder)
        {
            try
            {
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", folder, Hinh.FileName);
                using (var myfile = new FileStream(fullPath, FileMode.CreateNew))
                {
                    Hinh.CopyTo(myfile);
                }
                return Hinh.FileName;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

    }
}
