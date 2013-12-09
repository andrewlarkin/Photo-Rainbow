using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Photo_Rainbow
{
    class ImageProcessor
    {
        // 346-360, 0-15 -> Red -> 11
        // 16-45 -> Orange -> 0
        // 46-75 -> Yellow -> 1
        // 76-105 -> Yellow-Green -> 2
        // 106-135 -> Green -> 3
        // 136-165 -> Blue-Green -> 4
        // 166-195 -> Aqua -> 5
        // 196-225 -> Light Blue -> 6
        // 226-255 -> Blue -> 7
        // 256-285 -> Indigo -> 8
        // 286-315 -> Violet -> 9
        // 316-345 -> Pink -> 10
        List<string> colorLookup = new List<string>
        {
            "orange",
            "yellow",
            "yellow-green",
            "green",
            "green-blue",
            "aqua",
            "light-blue",
            "blue",
            "indigo",
            "violet",
            "pink",
            "red"
        };

        public void analyzeImage(Image image)
        {

        }

        public void getColorData(Bitmap image)
        {

        }

        private int imageWidth = 0;
        private int imageHeight = 0;
        //private float rangeValue = 0;
        private Dictionary<String, float> _brightnessColorDict = new Dictionary<string, float>();
        private Dictionary<String, List<Color>> _colorByPixel = new Dictionary<string, List<Color>>();
        private Dictionary<int, String> colorData = new Dictionary<int, string>();

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
            int i = 0, j = 0;
            Dictionary<string, decimal> colorData = new Dictionary<string, decimal>();
            int brightness;

            Dictionary<string, int> colorTally = new Dictionary<string, int>();
            float brightnessTally = 0;
            string color;

            this.imageWidth = imageAsBitmap.Width;
            this.imageHeight = imageAsBitmap.Height;

            foreach (string c in colorLookup)
            {
                colorTally.Add(c, 0);
            }

            try
            {
                for (i = 0; i < this.imageWidth; i += 1)
                {
                    for (j = 0; j < this.imageHeight; j += 1)
                    {
                        Color imgPixelColor = imageAsBitmap.GetPixel(i, j);
                        double hue = (double)imgPixelColor.GetHue();

                        color = colorLookup[(int)Math.Floor(Math.Abs(hue - 16) / 30)]; //Normalize the color data, get color from lookup table

                        colorTally[color] += 1;

                        // add to brightness  tally
                        brightnessTally += imgPixelColor.GetBrightness();
                    }
                }

                int totalPixels = this.imageHeight * this.imageWidth;

                foreach (var pair in colorTally)
                {
                    colorData.Add(pair.Key, pair.Value / totalPixels);
                }

                brightness = (int)Math.Floor(brightnessTally / totalPixels);
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
