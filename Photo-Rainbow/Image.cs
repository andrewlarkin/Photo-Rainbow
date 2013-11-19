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
        public static string url;
        private static Bitmap img;
        private ImageColorData colData;
        private String colName;

        public Image(string u)
        {
            url = u;
            Download();
            colName = "";
            colData = new ImageColorData(img);
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

        public String colorName
        {
            set { colName = value; }
            get { return colName; }
        }
        public float brightnessOfColor
        {
            get { return colData.calcAverageBrightnessByColor(colName); }
        }

        public float percentageOfColor
        {
            get { return colData.percentageOfColorInImage(colName); }
        }

    }
}
