using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace vt14_2_1_galleriet.Model
{
    public class Gallery
    {

        private readonly static Regex ApprovedExtension;

        private readonly static string PhysicalUploadImagePath;

        private readonly static Regex SantizePath;

        private static Gallery() // konstruktor..
        {
            ApprovedExtension = new Regex("^.*\\.(gif|jpg|png)$", RegexOptions.IgnoreCase);

            var invalidChars = new string(Path.GetInvalidFileNameChars());

            SantizePath = new Regex(string.Format("[{0}]", Regex.Escape(invalidChars)));

            PhysicalUploadImagePath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"pics");
            //↑Sökvägen är mer kompatibel med olika operativsystem etc..
        }

        public IEnumerable<string> GetImageNames()
        {
            throw new NotImplementedException();
        }

        public bool ImageExists(string name)
        {
            throw new NotImplementedException();
        }

        private bool isValidImage(Image image)
        {
            throw new NotImplementedException();
        }

        public string SaveImage(Stream stream, string fileName){
            throw new NotImplementedException();
        }

    }
}