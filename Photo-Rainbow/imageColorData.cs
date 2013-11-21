﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Photo_Rainbow
{
    class ImageColorData
    {
        private int imageWidth = 0;
        private int imageHeight = 0;
        private Dictionary<String, float> _brightnessColorDict = new Dictionary<string, float>();
        private Dictionary<String, List<Color>> _colorByPixel = new Dictionary<string, List<Color>>();


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
