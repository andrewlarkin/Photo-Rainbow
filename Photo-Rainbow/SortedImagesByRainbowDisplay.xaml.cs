using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Photo_Rainbow
{
    /// <summary>
    /// Interaction logic for SortedImagesByRainbowDisplay.xaml
    /// </summary>
    public partial class SortedImagesByRainbowDisplay : Window
    {
        private List<ImageDataStore> imgs;
        //private ImageColorData iCDObj = new ImageColorData();
        public SortedImagesByRainbowDisplay()
        {
            InitializeComponent();
        }

        public SortedImagesByRainbowDisplay(List<ImageDataStore> imgs)
        {
            this.imgs = imgs;
            InitializeComponent();
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        /*private void initializeImageColorDictionary()
        {
            foreach (Image imgObj in imgObjs)
            {
                iCDObj.GetColorData(imgObj);
            }
        }*/

    }
}
