using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Photo_Rainbow
{     
    public class ImageDataStore 
    {
        private ImageColorData iCDObj = new ImageColorData();
        private Dictionary<Image, Dictionary<String, float>> image7ColorsData;
        private List<Image> imgObjs;
        public ImageDataStore()
        {            
        }
        /*public ImageDataStore(List<Image> imgObjs)
        {
            this.imgObjs = imgObjs;
        }*/
        public Dictionary<Image, Dictionary<String, float>> Image7ColorsData
        {
            get { return image7ColorsData; }
            set { image7ColorsData = value; }
        }
        public List<Image> Images
        {
            get { return this.imgObjs; }
            set { imgObjs = value; }
        }
        public ImageColorData imgObjColorData
        {
            get { return iCDObj; }
            set { iCDObj = value; }
        }
    }
}
