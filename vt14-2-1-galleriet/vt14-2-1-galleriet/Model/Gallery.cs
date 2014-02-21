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

        static Gallery() // konstruktor..
        {
            ApprovedExtension = new Regex(@"^.*\.(gif|jpg|png)$", RegexOptions.IgnoreCase);

            var invalidChars = new string(Path.GetInvalidFileNameChars());

            SantizePath = new Regex(string.Format("[{0}]", Regex.Escape(invalidChars)));

            PhysicalUploadImagePath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"pics");
            //↑Sökvägen är mer kompatibel med olika operativsystem etc..
        }

        public IEnumerable<string> GetImageNames()
        {

            DirectoryInfo dInfo = new DirectoryInfo(PhysicalUploadImagePath);            

            var listOfFiles = dInfo.GetFiles();

            IEnumerable<string> ListOfNames = new IEnumerable<string>;
            
            
            

            for(var i = 0; i < listOfFiles.Length; i++)
            {
                ListOfNames. = listOfFiles[0].Name;
            }

            
        }

        public bool ImageExists(string name)
        {

            IEnumerable<string> listOfNames = GetImageNames();

            throw new NotImplementedException();
        }

        private bool isValidImage(Image image)
        {

            var png = System.Drawing.Imaging.ImageFormat.Png.Guid;
            var jpg = System.Drawing.Imaging.ImageFormat.Jpeg.Guid;
            var gif = System.Drawing.Imaging.ImageFormat.Gif.Guid;
            var thisPicMime = image.RawFormat.Guid;

            if (thisPicMime == png || thisPicMime == jpg || thisPicMime == gif) // om memetypen är samma i bilden som gif/jpg/png
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string SaveImage(Stream stream, string fileName){

            Image image = System.Drawing.Image.FromStream(stream); //converterar till Bild..

            if (isValidImage(image)) // om bilden har rätt meme-typ! 
            {
                if (ApprovedExtension.IsMatch(fileName)) // om filnamnet slutar på gif/png/jpg
                {
                    var newFileName = SantizePath.Replace(fileName, "_");// om namnet innehåller ogiltiga tecken ersätt dem.. (tror det är såhär man gör..
                    // om namnet inte är ogiltigt så sparas det giltiga nament ner i newFileName
                    ImageExists(newFileName);

                }
                else
                {
                    throw new InvalidDataException(); // kastar ett fel om att datan är ogiltig
                }

            }
            
            

            throw new NotImplementedException();
        }

    }
}