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
            // Varje gång sidan får en Get  vill jag kolla Query-Strängen om en bild ska laddas upp i bildvisaren..

            string qString = Convert.ToString(Request.QueryString); // hämtar ner QueryStringen och gemför med vad som finns i Pics, sen visar upp bild...

            var service = new service();

            var imageSource = service.GetPicFromThumbNailName(qString);

            if(imageSource != null && imageSource != ""){
                ImageHolder.ImageUrl = imageSource;
            }
            else
            {
                ImageHolder.ImageUrl = @"~\pics\bg.jpg";
            }
            
        }

        protected void uploadButton_Click(object sender, EventArgs e)
        {
            Gallery galleryObj = new Gallery();

            galleryObj.SaveImage(GalleryFileUploader.FileContent, GalleryFileUploader.FileName);

            
        }

        public IEnumerable<FileInfo> Repeater2_GetData()
        {

            service myService = new service();
            
            var h = myService.GetThumbNails(); 
            return h;
        }



    }
}