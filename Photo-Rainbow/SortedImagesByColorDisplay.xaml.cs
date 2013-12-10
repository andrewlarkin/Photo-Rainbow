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

    class DataGridItems
    {

        public float  percentage { get; set; }

        public Uri ImageFilePath { get; set; }
    }
    public partial class SortedImagesByColorDisplay : Window
    {
        private ImageDataStore imgsData;
        int count = 0;
        public SortedImagesByColorDisplay()
        {
            InitializeComponent();            
        }

        public SortedImagesByColorDisplay(ImageDataStore imgsData)
        {
            this.imgsData = imgsData;            
            InitializeComponent();            
        }

        private void Blue_Sort_Click(object sender, RoutedEventArgs e)
        {

            Dictionary<Image, float> blueDominantImages = getSortedImagesByColor("Blue");           
            LoadImages(blueDominantImages);
        }
        

        private void Violet_Sort_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<Image, float> violetDominantImages = getSortedImagesByColor("Violet");
            LoadImages(violetDominantImages);
        }

        private void Green_Sort_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<Image, float> greenDominantImages = getSortedImagesByColor("Green");
            LoadImages(greenDominantImages);
        }

        private void Indigo_Sort1_Click(object sender, RoutedEventArgs e)
        {
            //Image1.Items.Clear();
            Dictionary<Image, float> indigoDominantImages = getSortedImagesByColor("Indigo");
            LoadImages(indigoDominantImages);        
        }

        private void Yellow_Sort_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<Image, float> yellowDominantImages = getSortedImagesByColor("Yellow");
            LoadImages(yellowDominantImages);            

        }

        private void Orange_Sort_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<Image, float> orangeDominantImages = getSortedImagesByColor("Orange");
            LoadImages(orangeDominantImages);
        }

        private void Red_Sort_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<Image, float> redDominantImages = getSortedImagesByColor("Red");
            LoadImages(redDominantImages);
        }

        private void LoadImages(Dictionary<Image, float> imagesColorPercentDict)
        {            
            Image1.Items.Clear();          
           
            foreach (Image img in imagesColorPercentDict.Keys)
            {                
                    Image1.Items.Add(new DataGridItems() { ImageFilePath = new Uri(img.Url), percentage = imagesColorPercentDict[img] });                                
            }
        
        }

        //Ayesha Logic...
        private Dictionary<Image, float> getSortedImagesByColor(String color)
        {
            Dictionary<Image, float> dicImgHue = new Dictionary<Image, float>();
            var orderedItems2 = imgsData.Image7ColorsData.OrderByDescending(m => m.Value[color]).Select(n => new
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

    }

}