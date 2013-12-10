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
        private Dictionary<Image, Dictionary<String, float>> imageDataDictSorted  = new Dictionary<Image, Dictionary<String, float>>();

        public Dictionary<String, float> brightnessColorDict
        {
            get { return this._brightnessColorDict; }
        }

        public Dictionary<String, List<Color>> colorByPixel
        {
            get { return this._colorByPixel; }
        }
        public Dictionary<Image, Dictionary<String, float>> ImageDataDictForSort
        {
            get { return imageDataDictSorted; }
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
                    //Color.Red.GetHue() gives 0 degree
                    temp = pixelColorHue - Color.Red.GetHue();
                    temp = adjustHue(temp);
                    if (!imgVIBGYORHueDiffDict.ContainsKey(temp))
                    {
                        imgVIBGYORHueDiffDict.Add(temp, "Red");
                    }
                    //fringe case: Red have 2 degrees in a circle 0 and 360.
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
            return _colorByPixel;          
        }


        public float percentageOfColorInImage(String colorName)
        {
            float percentageOfColor = 0;
            if (_colorByPixel.ContainsKey(colorName))
            {
                float numberofPixelsByColor = _colorByPixel[colorName].Count();
                float totalPixelsInImage = imageWidth * imageHeight;
                percentageOfColor = (numberofPixelsByColor / totalPixelsInImage) * 100;
            }
            return percentageOfColor;
        }
        public float calcAverageBrightnessByColor(String colorName)
        {
            float averageBrightnessByColor = 0;
            if (_colorByPixel.ContainsKey(colorName))
            {
                int numberOfPixelsByColor = _colorByPixel[colorName].Count();
                averageBrightnessByColor = _brightnessColorDict[colorName] / numberOfPixelsByColor;
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

        /*public Dictionary<Bitmap, List<Dictionary<String, float>>> GetColorData(Image imgObj)
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
        }*/
    public void GetColorData(Image imgObj, String typeOfData)
    {
        initializeClassMembers();
        _colorByPixel = getColorsInImage(imgObj.Img);        
        if(typeOfData.Equals("percentage"))
        {           
            Dictionary<String, float> VIBGYORPercent = new Dictionary<string, float>();
            float percentage = percentageOfColorInImage("Violet");
            VIBGYORPercent.Add("Violet", percentage);
            percentage = percentageOfColorInImage("Indigo");
            VIBGYORPercent.Add("Indigo", percentage);
            percentage = percentageOfColorInImage("Blue");
            VIBGYORPercent.Add("Blue", percentage);
            percentage = percentageOfColorInImage("Green");
            VIBGYORPercent.Add("Green", percentage);
            percentage = percentageOfColorInImage("Yellow");
            VIBGYORPercent.Add("Yellow", percentage);
            percentage = percentageOfColorInImage("Orange");
            VIBGYORPercent.Add("Orange", percentage);
            percentage = percentageOfColorInImage("Red");
            VIBGYORPercent.Add("Red", percentage);
            imageDataDictSorted.Add(imgObj, VIBGYORPercent);
        }        
    }

        public void initializeClassMembers()
        {
            imageWidth = 0;
            imageHeight = 0;
            _brightnessColorDict = new Dictionary<string, float>();
            _colorByPixel = new Dictionary<string, List<Color>>();            
        }
    }
}
