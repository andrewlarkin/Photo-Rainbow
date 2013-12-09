using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net;
using System.IO;

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
