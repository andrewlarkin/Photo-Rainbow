using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Photo_Rainbow
{
    class ImageColorData2
    {
        private int imageWidth = 0;
        private int imageHeight = 0;
        private float rangeValue = 0;
        private Dictionary<String, float> _brightnessColorDict = new Dictionary<string, float>();
        private Dictionary<String, List<Color>> _colorByPixel = new Dictionary<string, List<Color>>();
        private Dictionary<float, String> imgVIBGYORHueDiffDict = new Dictionary<float, string>();

        public Dictionary<String, float> brightnessColorDict
        {
            get { return this._brightnessColorDict; }
        }

        public Dictionary<String, List<Color>> colorByPixel
        {
            get { return this._colorByPixel; }
        }

        public Dictionary<String, List<Color>> getColorsInImage(Bitmap imageAsBitmap)
        {
            int xCoord = 0, yCoord = 0;
            float temp = 0;
            this.imageWidth = imageAsBitmap.Width;
            this.imageHeight = imageAsBitmap.Height;

            try
            {
                for (xCoord = 0; xCoord < this.imageWidth; xCoord++)
                {
                    for (yCoord = 0; yCoord < this.imageHeight; yCoord++)
                    {
                        List<float> imgVIBGYORHueDiff = new List<float>();
                        //Dictionary<float, String> imgVIBGYORHueDiffDict = new Dictionary<float, string>();
                        Color imgPixelColor = imageAsBitmap.GetPixel(xCoord, yCoord);
                        float pixelColorHue = imgPixelColor.GetHue();
                        temp = pixelColorHue;
                        rangeValue = temp;

                        if (!imgVIBGYORHueDiffDict.ContainsKey(rangeValue))
                        {
                            if (Enumerable.Range(300, 360).Contains(Convert.ToInt32(rangeValue)))
                            {
                                imgVIBGYORHueDiffDict.Add(rangeValue, "Violet"); break;
                            }
                            else if (Enumerable.Range(275, 299).Contains(Convert.ToInt32(rangeValue)))
                            {
                                imgVIBGYORHueDiffDict.Add(rangeValue, "Indigo"); continue;
                            }
                            else if (Enumerable.Range(240, 274).Contains(Convert.ToInt32(rangeValue)))
                            {
                                imgVIBGYORHueDiffDict.Add(rangeValue, "Blue"); continue;
                            }
                            else if (Enumerable.Range(120, 239).Contains(Convert.ToInt32(rangeValue)))
                            {
                                imgVIBGYORHueDiffDict.Add(rangeValue, "Green"); continue;
                            }
                            else if (Enumerable.Range(60, 119).Contains(Convert.ToInt32(rangeValue)))
                            {
                                imgVIBGYORHueDiffDict.Add(rangeValue, "Yellow"); continue;
                            }
                            else if (Enumerable.Range(40, 59).Contains(Convert.ToInt32(rangeValue)))
                            {
                                imgVIBGYORHueDiffDict.Add(rangeValue, "Orange"); continue;
                            }
                            else if (Enumerable.Range(0, 39).Contains(Convert.ToInt32(rangeValue)))
                            {
                                imgVIBGYORHueDiffDict.Add(rangeValue, "Red"); continue;
                            }
                        }

                        foreach (float hueDiff in imgVIBGYORHueDiffDict.Keys)
                        {

                            imgVIBGYORHueDiff.Add(hueDiff);
                        }
                        float closestPixelColorByHue = imgVIBGYORHueDiff.Min();
                        if (_colorByPixel.ContainsKey(imgVIBGYORHueDiffDict[closestPixelColorByHue]))
                        {
                            _colorByPixel[imgVIBGYORHueDiffDict[closestPixelColorByHue]].Add(imgPixelColor);
                            _brightnessColorDict[imgVIBGYORHueDiffDict[closestPixelColorByHue]] += imgPixelColor.GetBrightness();
                        }
                        else
                        {
                            List<Color> pixelColorStructure = new List<Color>();
                            pixelColorStructure.Add(imgPixelColor);
                            _colorByPixel.Add(imgVIBGYORHueDiffDict[closestPixelColorByHue], pixelColorStructure);
                            _brightnessColorDict.Add(imgVIBGYORHueDiffDict[closestPixelColorByHue], imgPixelColor.GetBrightness());
                        }
                    }
                }
            }

            catch (Exception e)
            {

            }
            return _colorByPixel;
        }

        public float percentageOfColorInImage(String colorName)
        {
            float percentageOfColor = 0;
            try
            {
                float numberofPixelsByColor = _colorByPixel[colorName].Count();
                float totalPixelsInImage = imageWidth * imageHeight;
                percentageOfColor = (numberofPixelsByColor / totalPixelsInImage) * 100;
            }
            catch (Exception e)
            {

            }
            return percentageOfColor;
        }
        public float calcAverageBrightnessByColor(String colorName)
        {
            float averageBrightnessByColor = 0;
            try
            {
                int numberOfPixelsByColor = _colorByPixel[colorName].Count();
                averageBrightnessByColor = _brightnessColorDict[colorName] / numberOfPixelsByColor;
            }
            catch (Exception e)
            {

            }
            return averageBrightnessByColor;
        }
        private static float adjustHue(float temp)
        {
            if (temp < 0)
            {
                temp = temp * (-1);
                return temp;
            }
            else
            {
                return temp;
            }
        }
    }
}
