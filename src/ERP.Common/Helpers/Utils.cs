using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.Helpers
{
    public static class Utils
    {
        private static readonly string RootPath = @"C:\[UIT]";
        private static readonly string AppName = "ERP";

        public static string GetPathUpload()
        {
            return Path.Combine(RootPath, AppName, "Uploads");
        }
        public static string GetPathUploadProducts()
        {
            return Path.Combine(RootPath, AppName, "Uploads", "Products");
        }
    }
}
