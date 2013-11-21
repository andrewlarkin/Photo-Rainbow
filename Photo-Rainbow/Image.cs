using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;

namespace Photo_Rainbow
{
    public class Image
    {
        public static string url;
        private static Bitmap img;

        public Image()
        {
        }

        public Image(string u)
        {
            url = u;
        }

        public void Download()
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(url);

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

        //TODO: Create accessor for color data

        public string Url
        {
            set { url = value; }
            get { return url; }
        }

        public Bitmap Img
        {
            set { img = value; }
            get { return img; }
        }  
    }
}
