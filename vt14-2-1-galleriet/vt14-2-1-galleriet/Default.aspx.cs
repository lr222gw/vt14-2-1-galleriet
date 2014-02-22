using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vt14_2_1_galleriet.Model;


namespace vt14_2_1_galleriet
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void uploadButton_Click(object sender, EventArgs e)
        {
            Gallery galleryObj = new Gallery();

            galleryObj.SaveImage(GalleryFileUploader.FileContent, GalleryFileUploader.FileName);

            
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<FileInfo> ListView1_GetData()
        {
            service myService = new service();
            return myService.GetThumbNails();
        }


    }
}