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
    class ImageAnalysis
    {
        public void processImages()
        {
            string s;

            try
            {
                String WorkingDirectory = @"../../Images/";
                DirectoryInfo diWorking = new DirectoryInfo(WorkingDirectory);
                List<string> alMyPictureFiles = new List<string>();
                Regex rgxPictureFiles = new Regex(@"bmp|png|jpg|gif");

                if (diWorking.Exists)
                {
                    foreach (FileInfo objFile in diWorking.GetFiles())
                    {
                        if (rgxPictureFiles.Match(objFile.Extension).Success)
                        {
                            alMyPictureFiles.Add(objFile.FullName);
                        }
                    }
                }

                //int inBlocks = 100;
                int xFactor = 100;
                //processing images in parallel manner
       
                    Parallel.ForEach(alMyPictureFiles, currentFile =>
                    {
                        string filename = Path.GetFileName(currentFile);

                        using (Bitmap bitmap = new Bitmap(currentFile))
                        {
                            s = string.Format("Processing Image: {0} on thread: {1}", filename,
                              Thread.CurrentThread.ManagedThreadId);
                            SizeF dimensions = bitmap.PhysicalDimension;
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
                                    // ToDo: call processing 
                                    cloneBitmap.Dispose();
                                   
                                });
                            }
                            else
                            {
                                // ToDo: call processing 
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
