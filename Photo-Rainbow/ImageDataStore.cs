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
        private List<Image> imgObjs;
        public ImageDataStore()
        {            
        }
        public ImageDataStore(List<Image> imgObjs)
        {
            this.imgObjs = imgObjs;
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
