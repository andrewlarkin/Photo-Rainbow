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
    /// Interaction logic for SortedImagesByColorDisplay.xaml
    /// </summary>
    public partial class SortedImagesByColorDisplay : Window
    {
        private List<Image> imgObjs;
        private ImageColorData iCDObj = new ImageColorData();
        public SortedImagesByColorDisplay()
        {
            InitializeComponent();            
        }

        public SortedImagesByColorDisplay(List<Image> imgObjs)
        {
            this.imgObjs = imgObjs;            
            InitializeComponent();
            initializeImageColorDictionary();
        }

        private void Blue_Sort_Click(object sender, RoutedEventArgs e)
        {
            List<Image> blueDominantImages = iCDObj.getSortedImagesByColor("Blue");
            LoadImages(blueDominantImages);
        }
        

        private void Violet_Sort_Click(object sender, RoutedEventArgs e)
        {
            List<Image> violetDominantImages = iCDObj.getSortedImagesByColor("Violet");
            LoadImages(violetDominantImages);
        }

        private void Green_Sort_Click(object sender, RoutedEventArgs e)
        {
            List<Image> greenDominantImages = iCDObj.getSortedImagesByColor("Green");
            LoadImages(greenDominantImages);
        }

        private void Indigo_Sort1_Click(object sender, RoutedEventArgs e)
        {
            List<Image> indigoDominantImages = iCDObj.getSortedImagesByColor("Indigo");
            LoadImages(indigoDominantImages);        
        }

        private void Yellow_Sort_Click(object sender, RoutedEventArgs e)
        {
            List<Image> yellowDominantImages = iCDObj.getSortedImagesByColor("Yellow");
            //LoadImages(yellowDominantImages);
            ImagesColorOrderedBox.Items.Clear();
        }

        private void Orange_Sort_Click(object sender, RoutedEventArgs e)
        {
            List<Image> orangeDominantImages = iCDObj.getSortedImagesByColor("Orange");
            LoadImages(orangeDominantImages);
        }

        private void Red_Sort_Click(object sender, RoutedEventArgs e)
        {
            List<Image> redDominantImages = iCDObj.getSortedImagesByColor("Red");
            LoadImages(redDominantImages);
        }

        private void LoadImages(List<Image> imgObjs)
        {
            ImagesColorOrderedBox.Items.Clear();
            foreach(Image img in imgObjs)
            {
                System.Windows.Controls.Image userImage = new System.Windows.Controls.Image();
                userImage.Height = 100;
                userImage.Width = 100;

                BitmapImage userImageSource = new BitmapImage();
                userImageSource.BeginInit();
                userImageSource.UriSource = new Uri(img.Url);
                userImageSource.EndInit();
                userImage.Source = userImageSource;

                ImagesColorOrderedBox.Items.Add(userImage);
            }
        }

        private void initializeImageColorDictionary()
        {
            foreach(Image imgObj in imgObjs)
            {
                iCDObj.GetColorData(imgObj);
            }
        }
       
    }
}
