using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace JohnsBlog.Helpers
{
    public class DisplayImageUpload
    {
        public static string DisplayImage(string filePath)
        {
            var fileName = filePath;

            switch (Path.GetExtension(filePath)) //switch(".txt")
            {
                case ".doc":
                    fileName = "/Images/DefaultDoc.png";
                    break;
                case ".docx":
                    fileName = "/Images/DefaultDocx.png";
                    break;
                case ".pdf":
                    fileName = "/Images/DefaultPdf.png";
                    break;
                case ".xls":
                    fileName = "/Images/DefaultXls.png";
                    break;
                case ".xlsx":
                    fileName = "/Images/DefaultXlsx.png";
                    break;
                case ".txt":
                    fileName = "/Images/DefaultTxt.png";
                    break;
                default:
                    break;
            }
            return fileName;
        }
    }
}