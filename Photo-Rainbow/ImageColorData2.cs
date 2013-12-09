using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Photo_Rainbow
{
    public class ImageColorData2
    {
        private int imageWidth = 0;
        private int imageHeight = 0;
        private float rangeValue = 0;
        private Dictionary<String, float> _brightnessColorDict = new Dictionary<string, float>();
        private Dictionary<String, List<Color>> _colorByPixel = new Dictionary<string, List<Color>>();
        private Dictionary<float, String> imgVIBGYORHueDiffDict = new Dictionary<float, string>();
        private Dictionary<Image, Dictionary<String, float>> imageDataDictSorted = new Dictionary<Image, Dictionary<String, float>>();
        public Dictionary<String, float> brightnessColorDict
        {
            get { return this._brightnessColorDict; }
        }

        public Dictionary<String, List<Color>> colorByPixel
        {
            get { return this._colorByPixel; }
        }

        //Ayesha Logic...
        internal Dictionary<Image, float> getSortedImagesByColor(String color)
        {
            Dictionary<Image, float> dicImgHue = new Dictionary<Image, float>();
            var orderedItems2 = imageDataDictSorted.OrderByDescending(m => m.Value[color]).Select(n => new
            {
                ImageName = n.Key,
                Hue = n.Value[color]
            }).ToList();
            foreach (var v in orderedItems2)
            {
                dicImgHue.Add(v.ImageName, v.Hue);
            }
            return dicImgHue;
        }

        internal Dictionary<Image, Dictionary<String, float>> getSortedImagesByRainbow()
        {
            Dictionary<Image, Dictionary<String, float>> dicImgRainbowHue = new Dictionary<Image, Dictionary<String, float>>();
            var orderedItems2 = imageDataDictSorted.OrderByDescending(m => m.Value["Violet"]).ThenBy(m => m.Value["Indigo"]).ThenBy(m => m.Value["Blue"]).ThenBy(m => m.Value["Green"]).ThenBy(m => m.Value["Yellow"]).ThenBy(m => m.Value["Orange"]).ThenBy(m => m.Value["Red"]).Select(n => new
            {
                ImageName = n.Key,
                VIBGYORDict = n.Value
            }).ToList();
            foreach (var v in orderedItems2)
            {
                dicImgRainbowHue.Add(v.ImageName, v.VIBGYORDict);
            }
            return dicImgRainbowHue;
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

        public Dictionary<Bitmap, List<Dictionary<String, float>>> GetColorData2(Image imgObj)
        {
            _colorByPixel = getColorsInImage(imgObj.Img);
            Dictionary<Bitmap, List<Dictionary<String, float>>> imageDataDict = new Dictionary<Bitmap, List<Dictionary<String, float>>>();
            Dictionary<String, float> colPercentageDict = new Dictionary<String, float>();
            List<Dictionary<String, float>> imgInfoDictList = new List<Dictionary<string, float>>();
            colPercentageDict.Add("Violet", percentageOfColorInImage("Violet"));
            colPercentageDict.Add("Indigo", percentageOfColorInImage("Indigo"));
            colPercentageDict.Add("Blue", percentageOfColorInImage("Blue"));
            colPercentageDict.Add("Green", percentageOfColorInImage("Green"));
            colPercentageDict.Add("Yellow", percentageOfColorInImage("Yellow"));
            colPercentageDict.Add("Orange", percentageOfColorInImage("Orange"));
            colPercentageDict.Add("Red", percentageOfColorInImage("Red"));
            imgInfoDictList.Add(colPercentageDict);

            Dictionary<String, float> colAvgBrightnessDict = new Dictionary<String, float>();
            colAvgBrightnessDict.Add("Violet", calcAverageBrightnessByColor("Violet"));
            colAvgBrightnessDict.Add("Indigo", calcAverageBrightnessByColor("Indigo"));
            colAvgBrightnessDict.Add("Blue", calcAverageBrightnessByColor("Blue"));
            colAvgBrightnessDict.Add("Green", calcAverageBrightnessByColor("Green"));
            colAvgBrightnessDict.Add("Yellow", calcAverageBrightnessByColor("Yellow"));
            colAvgBrightnessDict.Add("Orange", calcAverageBrightnessByColor("Orange"));
            colAvgBrightnessDict.Add("Red", calcAverageBrightnessByColor("Red"));
            imgInfoDictList.Add(colAvgBrightnessDict);
            imageDataDict.Add(imgObj.Img, imgInfoDictList);
            imageDataDictSorted.Add(imgObj, colPercentageDict);
            return imageDataDict;
        }

        public float percentageOfColorInImage(String colorName)
        {
            float percentageOfColor = 0;
            if(_colorByPixel.ContainsKey(colorName))
            {
                float numberofPixelsByColor = _colorByPixel[colorName].Count();
                float totalPixelsInImage = imageWidth * imageHeight;
                percentageOfColor = (numberofPixelsByColor / totalPixelsInImage) * 100;
                return percentageOfColor;
            }
            else
                return percentageOfColor;
        }
        public float calcAverageBrightnessByColor(String colorName)
        {
            float averageBrightnessByColor = 0;
            if(_colorByPixel.ContainsKey(colorName))
            {
                int numberOfPixelsByColor = _colorByPixel[colorName].Count();
                averageBrightnessByColor = _brightnessColorDict[colorName] / numberOfPixelsByColor;
                return averageBrightnessByColor;
            }
            else
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
