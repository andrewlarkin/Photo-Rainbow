using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net;
using System.IO;
using System.Windows.Media.Imaging;
namespace Photo_Rainbow
{
    public class Image 
    {
        public String imageUrl = "";
        private Bitmap img = null;        
        public Image(String imgUrl)
        {
            imageUrl = imgUrl;
            Download();            
        }
        public Image()
        {

        }
        
        public void Download()
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(imageUrl);

            try
            {
                img = new Bitmap(stream);
                Bitmap scaledImage = new Bitmap(img, new Size(100, 100));
                img = scaledImage;
                stream.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                stream.Close();
            }
        }
        

        public void setUniformDimensions()
        {
            
        }
        //TODO: Create accessor for color data

        public string Url
        {
            set { imageUrl = value; }
            get { return imageUrl; }
        }
        
        public Bitmap Img
        {
            set { img = value; }
            get { return img; }
        }
             
    }
}
