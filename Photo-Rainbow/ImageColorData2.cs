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
        private Dictionary<float, String> imgVIBGYORHueDiffDict2 = new Dictionary<float, string>();

        public Dictionary<String, float> brightnessColorDict
        {
            get { return this._brightnessColorDict; }
        }

        public Dictionary<String, List<Color>> colorByPixel
        {
            get { return this._colorByPixel; }
        }
        
        public Dictionary<String,List<Color>> getColorsInImage(Bitmap imageAsBitmap)
        {            
            int xCoord = 0, yCoord = 0;
            float temp = 0;            
            this.imageWidth = imageAsBitmap.Width;
            this.imageHeight = imageAsBitmap.Height;
            var dispatcher = new DispatchTable<string>();
            dispatcher.AddAction("Violet", Violet);
            dispatcher.AddAction("Indigo", Indigo);
            dispatcher.AddAction("Blue", Blue);
            dispatcher.AddAction("Green", Green);
            dispatcher.AddAction("Yellow", Yellow);
            dispatcher.AddAction("Orange", Orange);
            dispatcher.AddAction("Red", Red);

            try
            {
                for (xCoord = 0; xCoord < this.imageWidth; xCoord++)
                {
                    for (yCoord = 0; yCoord < this.imageHeight; yCoord++)
                    {                        
                        List<float> imgVIBGYORHueDiff = new List<float>();
                        Dictionary<float, String> imgVIBGYORHueDiffDict = new Dictionary<float, string>();
                        Color imgPixelColor = imageAsBitmap.GetPixel(xCoord, yCoord);
                        float pixelColorHue = imgPixelColor.GetHue();
                        temp = pixelColorHue; 
                        rangeValue = temp;

                        if (!imgVIBGYORHueDiffDict2.ContainsKey(rangeValue))
                        {
                            if (Enumerable.Range(300, 360).Contains(Convert.ToInt32(rangeValue)))
                            {
                                dispatcher.Dispatch("Violet"); continue;
                            }
                            if (Enumerable.Range(275, 299).Contains(Convert.ToInt32(rangeValue)))
                            {
                                dispatcher.Dispatch("Indigo"); continue;
                            }
                            if (Enumerable.Range(240, 274).Contains(Convert.ToInt32(rangeValue)))
                            {
                                dispatcher.Dispatch("Blue"); continue;
                            }
                            if (Enumerable.Range(120, 239).Contains(Convert.ToInt32(rangeValue)))
                            {
                                dispatcher.Dispatch("Green"); continue;
                            }
                            if (Enumerable.Range(60, 119).Contains(Convert.ToInt32(rangeValue)))
                            {
                                dispatcher.Dispatch("Yellow");
                                continue;
                            }
                            if (Enumerable.Range(40, 59).Contains(Convert.ToInt32(rangeValue)))
                            {
                                dispatcher.Dispatch("Orange"); continue;
                            }
                            if (Enumerable.Range(0, 39).Contains(Convert.ToInt32(rangeValue)))
                            {
                                dispatcher.Dispatch("Red");
                                continue;
                            }
                        }

                        foreach (float hueDiff in imgVIBGYORHueDiffDict.Keys)
                        {

                            imgVIBGYORHueDiff.Add(hueDiff);
                        }
                        float closestPixelColorByHue = imgVIBGYORHueDiff.Min();
                        if (_colorByPixel.ContainsKey(imgVIBGYORHueDiffDict2[closestPixelColorByHue]))
                        {
                            _colorByPixel[imgVIBGYORHueDiffDict2[closestPixelColorByHue]].Add(imgPixelColor);
                            _brightnessColorDict[imgVIBGYORHueDiffDict2[closestPixelColorByHue]] += imgPixelColor.GetBrightness();
                        }
                        else
                        {
                            List<Color> pixelColorStructure = new List<Color>();
                            pixelColorStructure.Add(imgPixelColor);
                            _colorByPixel.Add(imgVIBGYORHueDiffDict2[closestPixelColorByHue], pixelColorStructure);
                            _brightnessColorDict.Add(imgVIBGYORHueDiffDict2[closestPixelColorByHue], imgPixelColor.GetBrightness());
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


        public void Violet() 
        {
            
                rangeValue = rangeValue - Color.Violet.GetHue();
                if (!imgVIBGYORHueDiffDict2.ContainsKey(rangeValue))
                {
                imgVIBGYORHueDiffDict2.Add(rangeValue, "Violet");
                }
                rangeValue = 0;           
        }

        public void Indigo() 
        {        
                rangeValue = rangeValue - Color.Indigo.GetHue();
                if (!imgVIBGYORHueDiffDict2.ContainsKey(rangeValue))
                {
                imgVIBGYORHueDiffDict2.Add(rangeValue, "Indigo");
                }
            rangeValue = 0;
            
        }
        public void Blue()
        {
            rangeValue = rangeValue - Color.Blue.GetHue();
            if (!imgVIBGYORHueDiffDict2.ContainsKey(rangeValue))
            {
                imgVIBGYORHueDiffDict2.Add(rangeValue, "Blue");
            }
            rangeValue = 0;          
        }

        public void Green()
        {
                rangeValue = rangeValue - Color.Green.GetHue();
                if (!imgVIBGYORHueDiffDict2.ContainsKey(rangeValue))
                {
                    imgVIBGYORHueDiffDict2.Add(rangeValue, "Green");
                }
                rangeValue = 0;
            
        }
        public void Yellow()
        {
            
                rangeValue = rangeValue - Color.Yellow.GetHue();
                if (!imgVIBGYORHueDiffDict2.ContainsKey(rangeValue))
                {
                imgVIBGYORHueDiffDict2.Add(rangeValue, "Yellow");
                }
                rangeValue = 0;
            
        }
        public void Orange()
        {
            
                rangeValue = rangeValue - Color.Orange.GetHue();
                if (!imgVIBGYORHueDiffDict2.ContainsKey(rangeValue))
                {
                imgVIBGYORHueDiffDict2.Add(rangeValue, "Orange");
                }
                rangeValue = 0;
            
        }
        public void Red()
        {
            
                rangeValue = rangeValue - Color.Red.GetHue();
                if (!imgVIBGYORHueDiffDict2.ContainsKey(rangeValue))
                {
                imgVIBGYORHueDiffDict2.Add(rangeValue, "Red");
                }
            rangeValue = 0;
            
        }
    }

    //public class Main
    //{
    //    public static int Main()
    //    {
    //        var dispatcher = new DispatchTable<string>();
    //        dispatcher.AddAction("paper", Paper);
    //        dispatcher.AddAction("rock", Rock);
    //        dispatcher.AddAction("scissors", Scissors);

    //        dispatcher.Dispatch("paper");
    //    }

    //    public void Paper() { }
    //    public void Scissors() { }
    //    public void Rock() { }  

    //}

    public class DispatchTable<T>
    {
        private readonly Dictionary<T, Action> table = new Dictionary<T, Action>();

        public void AddAction(T key, Action action) { table[key] = action; }

        public void Dispatch(T key)
        {
            Action action;
            if (table.TryGetValue(key, out action))
            {
                action();
            }
            else throw new InvalidOperationException("Action not supported: " + key.ToString());
        }
    }
}
