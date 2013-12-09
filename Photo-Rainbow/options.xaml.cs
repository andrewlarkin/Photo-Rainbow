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
using System.Drawing;

namespace Photo_Rainbow
{
    /// <summary>
    /// Interaction logic for options.xaml
    /// </summary>
    public partial class options : Window
    {
        private ImageDataStore imgsData;
        public options()
        {
            InitializeComponent();
        }
        public options(ImageDataStore imgsData)
        {
            InitializeComponent();
            this.imgsData = imgsData;
        }

        private void Color_Sort_Button_Click(object sender, RoutedEventArgs e)
        {
            
            SortedImagesByColorDisplay sIBCD = new SortedImagesByColorDisplay(imgsData);
            sIBCD.Show();

        }

        private void Rainbow_Sort_Button_Click(object sender, RoutedEventArgs e)
        {
            SortedImagesByRainbowDisplay sIBRD = new SortedImagesByRainbowDisplay(imgsData);
            sIBRD.Show();
        }
    }
}
