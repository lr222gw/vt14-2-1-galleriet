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