using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace vt14_2_1_galleriet.Model
{
    public class service
    {
        
        private Gallery _gallery;

        public Gallery Gallery
        {
            get { return _gallery ?? (_gallery = new Gallery()); } // lazy installation, behöver inte instansiera Gallery nån mer gång :) (typ..? )
        }

        public string GetPicFromThumbNailName(string thumbNailImg)
        {
            List<string> path = GetPaths();

            DirectoryInfo imgPath = new DirectoryInfo(path[0]);

            var fileListFromPicFolder = imgPath.GetFiles();

            for (var i = 0; i < fileListFromPicFolder.Length; i++ )
            {
                if (HttpUtility.UrlEncode(fileListFromPicFolder[i].Name) == thumbNailImg) // eftersom jag Encodat Thumbnailsen i aspx filen så gör jag det här. Encodeningen SKA vara samma.. (annars kan jag ej gemföra..)
                {
                    return  @"~\pics\" +fileListFromPicFolder[i].Name; //om matchat, returnera det som behövs för att bilden ska kunna synas i en IMG-tagg som src...
                }
            }

            return null;
        }


        public IEnumerable<FileInfo> GetThumbNails()
        {

            List<string> paths = GetPaths();
            string thumbNailPath = paths[1];

            DirectoryInfo thumbNailDir = new DirectoryInfo(thumbNailPath);

            var images = thumbNailDir.GetFiles();

            return images;
            
        }

        private List<string> GetPaths()
        {
            List<string> pathList = Gallery.getPaths();
            return pathList;
        }



    }
}