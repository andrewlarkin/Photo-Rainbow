using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Photo_Rainbow
{
    public class ImageColorData
    {
        private int imageWidth;
        private int imageHeight;
        private Dictionary<String, float> _brightnessColorDict;
        private Dictionary<String, List<Color>> _colorByPixel;

        private Dictionary<String, List<float>> _colorKeyPixValue;
        private Dictionary<Image, Dictionary<String, float>> imageDataDictSorted = new Dictionary<Image, Dictionary<String, float>>();

        public Dictionary<String, List<float>> colorKeyPixValue
        {
            get { return _colorKeyPixValue; }
        }

        public Dictionary<String, float> brightnessColorDict
        {
            get { return this._brightnessColorDict; }
        }

        public Dictionary<String, List<Color>> colorByPixel
        {
            get { return this._colorByPixel; }
        }

        public ImageColorData()
        {
            initializeClassMembers();
        }
       
        internal Dictionary<String,List<Color>> getColorsInImage(Bitmap imageAsBitmap)
        {            
            int xCoord = 0, yCoord = 0;
            float temp = 0;            
            this.imageWidth = imageAsBitmap.Width;
            this.imageHeight = imageAsBitmap.Height;
                
            for (xCoord = 0; xCoord < this.imageWidth; xCoord++)
            {
                for (yCoord = 0; yCoord < this.imageHeight; yCoord++)
                {
                    Dictionary<float, String> imgVIBGYORHueDiffDict = new Dictionary<float, string>();                    
                    List<float> imgVIBGYORHueDiff = new List<float>();
                    Color imgPixelColor = imageAsBitmap.GetPixel(xCoord, yCoord);                    
                    float pixelColorHue = imgPixelColor.GetHue();
                    temp = pixelColorHue - Color.Violet.GetHue();
                    temp = adjustHue(temp);
                    imgVIBGYORHueDiffDict.Add(temp, "Violet");

                    temp = pixelColorHue - Color.Indigo.GetHue();
                    temp = adjustHue(temp);
                    if (!imgVIBGYORHueDiffDict.ContainsKey(temp))
                    {
                        imgVIBGYORHueDiffDict.Add(temp, "Indigo");
                    }

                    temp = pixelColorHue - Color.Blue.GetHue();
                    temp = adjustHue(temp);
                    if (!imgVIBGYORHueDiffDict.ContainsKey(temp))
                    {
                        imgVIBGYORHueDiffDict.Add(temp, "Blue");
                    }
                        
                    temp = pixelColorHue - Color.Green.GetHue();
                    temp = adjustHue(temp);
                    if (!imgVIBGYORHueDiffDict.ContainsKey(temp))
                    {
                        imgVIBGYORHueDiffDict.Add(temp, "Green");
                    }
                        
                    temp = pixelColorHue - Color.Yellow.GetHue();
                    temp = adjustHue(temp);
                    if (!imgVIBGYORHueDiffDict.ContainsKey(temp))
                    {
                        imgVIBGYORHueDiffDict.Add(temp, "Yellow");
                    }

                    temp = pixelColorHue - Color.Orange.GetHue();
                    temp = adjustHue(temp);
                    if (!imgVIBGYORHueDiffDict.ContainsKey(temp))
                    {
                        imgVIBGYORHueDiffDict.Add(temp, "Orange");
                    }

                    temp = pixelColorHue - Color.Red.GetHue();
                    temp = adjustHue(temp);
                    if (!imgVIBGYORHueDiffDict.ContainsKey(temp))
                    {
                        imgVIBGYORHueDiffDict.Add(temp, "Red");
                    }

                    //Color Red has 2 hues one is 0 degree and another is 360 degree.
                    //C# GetHue() method gives only 0 degree.
                    temp = pixelColorHue - 360;
                    temp = adjustHue(temp);
                    if (!imgVIBGYORHueDiffDict.ContainsKey(temp))
                    {
                        imgVIBGYORHueDiffDict.Add(temp, "Red");
                    }
                    foreach (float hueDiff in imgVIBGYORHueDiffDict.Keys)
                    {
                        imgVIBGYORHueDiff.Add(hueDiff);
                    }
                    float closestPixelColorByHue = imgVIBGYORHueDiff.Min();
                    if (_colorByPixel.ContainsKey(imgVIBGYORHueDiffDict[closestPixelColorByHue]))
                    {
                        _colorByPixel[imgVIBGYORHueDiffDict[closestPixelColorByHue]].Add(imgPixelColor);
                        _colorKeyPixValue[imgVIBGYORHueDiffDict[closestPixelColorByHue]].Add(pixelColorHue);
                        _brightnessColorDict[imgVIBGYORHueDiffDict[closestPixelColorByHue]] += imgPixelColor.GetBrightness();
                    }
                    else
                    {
                        List<Color> pixelColorStructure = new List<Color>();
                        List<float> pixelsHues = new List<float>();
                        pixelColorStructure.Add(imgPixelColor);
                        pixelsHues.Add(pixelColorHue);
                        _colorByPixel.Add(imgVIBGYORHueDiffDict[closestPixelColorByHue], pixelColorStructure);
                        _colorKeyPixValue.Add(imgVIBGYORHueDiffDict[closestPixelColorByHue], pixelsHues);
                        _brightnessColorDict.Add(imgVIBGYORHueDiffDict[closestPixelColorByHue], imgPixelColor.GetBrightness()); 
                    }                                     
                }
            }
            return _colorByPixel;                
        }
        

        public float percentageOfColorInImage(String colorName)
        {
            if (_colorByPixel.ContainsKey(colorName))
            {
                float numberofPixelsByColor = _colorByPixel[colorName].Count();
                float totalPixelsInImage = imageWidth * imageHeight;
                //float percentageOfColor = (numberofPixelsByColor / totalPixelsInImage) * 100;
                float percentageOfColor = (numberofPixelsByColor / totalPixelsInImage);
                return percentageOfColor;
            }
            else
                return 0;
        }
        public float calcAverageBrightnessByColor(String colorName)
        {
            if (_colorByPixel.ContainsKey(colorName))
            {
                float averageBrightnessByColor = 0;
                int numberOfPixelsByColor = _colorByPixel[colorName].Count();
                averageBrightnessByColor = _brightnessColorDict[colorName] / numberOfPixelsByColor;
                return averageBrightnessByColor;
            }
            else
                return 0;
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

        public Dictionary<Bitmap, List<Dictionary<String, float>>> GetColorData(Image imgObj)
        {
            _colorByPixel = getColorsInImage(imgObj.Img);
            Dictionary<Bitmap, List<Dictionary<String, float>>> imageDataDict = new Dictionary<Bitmap, List<Dictionary<String, float>>>();
            Dictionary<String, float> colPercentageDict = new Dictionary<String, float>();
            List<Dictionary<String, float>> imgInfoDictList = new List<Dictionary<string,float>>();
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

        public void initializeClassMembers()
        {
            imageWidth = 0;
            imageHeight = 0;
            _brightnessColorDict = new Dictionary<string, float>();
            _colorByPixel = new Dictionary<string, List<Color>>();
            _colorKeyPixValue = new Dictionary<String, List<float>>();
        }
    }
}
