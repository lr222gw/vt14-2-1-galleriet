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

        private readonly static string PhysicalUploadThumbnailPath;

        private readonly static Regex SantizePath;

        static Gallery() // konstruktor..
        {
            ApprovedExtension = new Regex(@"^.*\.(gif|jpg|png)$", RegexOptions.IgnoreCase);

            var invalidChars = new string(Path.GetInvalidFileNameChars());

            SantizePath = new Regex(string.Format("[{0}]", Regex.Escape(invalidChars)));

            PhysicalUploadImagePath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"pics");
            //↑Sökvägen är mer kompatibel med olika operativsystem etc..

            PhysicalUploadThumbnailPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"pics/thumbnails");
        }

        public List<string> getPaths()
        {
            List<string> pathList = new List<string>();

            pathList.Add(PhysicalUploadImagePath);      // Metoden gör att pathList[0] blir vägen till vanliga bildmappen
            pathList.Add(PhysicalUploadThumbnailPath);  // Metoden gör att pathList[1] blir vägen till thumbnail bildmappen

            return pathList;
        }

        public IEnumerable<string> GetImageNames()
        {

            DirectoryInfo dInfo = new DirectoryInfo(PhysicalUploadImagePath);   // hämtar ner info om Directoryn        

            var listOfFiles = dInfo.GetFiles(); // tar fram en lista över filer

            List<string> ListOfNames = new List<string>(); // Skapar en Lista för att lagra namnen

            for(var i = 0; i < listOfFiles.Length; i++) // gör en loop som loopar igenom alla filer i Pics-mappen
            {
                ListOfNames.Add(listOfFiles[i].Name); // För varje fil läggs filens namn till i ListOfNames 
            }

            return ListOfNames.AsEnumerable<string>(); // Returnerar tillbaka listan som IEnumerable<string>

            
        }

        public string ImageExists(string name) //denna metod kollar om namnet finns, om det redan finns så ändrar den namnet..
        {

            IEnumerable<string> listOfNames = GetImageNames();

            var listOfNamesList  = listOfNames.ToList<string>();

            var fileExt = Path.GetExtension(name); // tar reda på filens "extension" 

            name = name.Remove(name.Length - (fileExt.Length), (fileExt.Length)); // tar bort filens "extension"

            for (var i = 0; i < listOfNamesList.Count; i++)
            {
                if (listOfNamesList[i] == name + fileExt) // kollar om det fullständiga namnet finns i listan
                {
                    name += "(1)";  //om den finns i listan, lägg till (1) till namnet
                    for(var j = 1; listOfNamesList[i] == name + "("+j+")"; j++) // kontrollera att namnet + (1) inte finns, om det finns, blir (1) istället (2) osv, tills ett ledigt nummer dyker upp..
                    {
                        name += "(" + j + ")";
                    }
                } 
            }

            return name + fileExt; // lägger till filens Extension
        }

        private bool isValidImage(Image image)
        {

            var png = System.Drawing.Imaging.ImageFormat.Png.Guid; // Skapar variabler för de olika filtyperna, lättare att hantera..
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
                    string finalName = ImageExists(newFileName); // Final name är det slutgiltiga namnet, efter att eventuell indexering samt de ogiltiga tecknerna tagits bort!                   

                    var thumbNail = image.GetThumbnailImage(60, 45, null, System.IntPtr.Zero);  // skapar en Thumbnail till bilden..
                    try
                    {
                        thumbNail.Save(Path.Combine(PhysicalUploadThumbnailPath, finalName)); // Sparar ner till sökvägen för Path + Namnet på filen..
                        image.Save(Path.Combine(PhysicalUploadImagePath, finalName));

                        return "Bilden laddas upp !";

                    }catch(Exception)
                    {
                        throw new ArgumentException("Något blev fel vid nedsparningen av bilden...");
                    }
                    
                }
                else
                {
                    throw new InvalidDataException(); // kastar ett fel om att datan är ogiltig
                }

            }
            return "Datan i bilden är ogiltig.";
            
        }

    }
}