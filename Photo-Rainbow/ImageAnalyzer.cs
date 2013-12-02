using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Photo_Rainbow
{
    class ImageAnalyzer
    {
        private List<Image> procImages = new List<Image>();
        private Dictionary<String, List<System.Drawing.Color>> imgColor;
        private ImageColorData img = new ImageColorData();

        public ImageAnalyzer(List<Image> images)
        {
            procImages = images;
            processImages();
        }

        public void processImages()
        {
            string s;

            try
            {
                int xFactor = 100;

                Parallel.ForEach(procImages, currentFile =>
                {
                    using (Bitmap bitmap = new Bitmap(currentFile.Img))
                    {
                        s = string.Format("Processing Image: {0} on thread: {1}", currentFile.Img.ToString(),
                          Thread.CurrentThread.ManagedThreadId);
                        SizeF dimensions = bitmap.PhysicalDimension;
                        //if (dimensions.Width > 50) use for testing
                        if (dimensions.Width > 1000)
                        {
                            int iSegments = (int)dimensions.Width / xFactor;
                            int remainderWidth = (int)dimensions.Width % xFactor;
                            int yFactor = (int)dimensions.Height;
                            Parallel.For(0, iSegments, segment =>
                            {
                                int startX = 0 + (segment * xFactor);
                                int xWidth = (remainderWidth != 0 && segment == iSegments) ? remainderWidth : (xFactor);
                                Rectangle cloneRect = new Rectangle(startX, 0, xFactor, yFactor);
                                PixelFormat format = bitmap.PixelFormat;
                                Bitmap cloneBitmap = bitmap.Clone(cloneRect, format);
                                imgColor = img.getColorsInImage(cloneBitmap);

                                cloneBitmap.Dispose();

                            });
                        }
                        else
                        {
                            imgColor = img.getColorsInImage(currentFile.Img);
                        }
                    }
                });

            }
            catch (Exception e)
            {
            }
        }
    }
}
