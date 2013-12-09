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
            Dictionary<Image, float> blueDominantImages = imgsData.imgObjColorData.getSortedImagesByColor("Blue");            
            LoadImages(blueDominantImages);
        }
        

        private void Violet_Sort_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<Image, float> violetDominantImages = imgsData.imgObjColorData.getSortedImagesByColor("Violet");
            LoadImages(violetDominantImages);
        }

        private void Green_Sort_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<Image, float> greenDominantImages = imgsData.imgObjColorData.getSortedImagesByColor("Green");
            LoadImages(greenDominantImages);
        }

        private void Indigo_Sort1_Click(object sender, RoutedEventArgs e)
        {
            //Image1.Items.Clear();
            Dictionary<Image, float> indigoDominantImages = imgsData.imgObjColorData.getSortedImagesByColor("Indigo");
            LoadImages(indigoDominantImages);        
        }

        private void Yellow_Sort_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<Image, float> yellowDominantImages = imgsData.imgObjColorData.getSortedImagesByColor("Yellow");
            LoadImages(yellowDominantImages);            

        }

        private void Orange_Sort_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<Image, float> orangeDominantImages = imgsData.imgObjColorData.getSortedImagesByColor("Orange");
            LoadImages(orangeDominantImages);
        }

        private void Red_Sort_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<Image, float> redDominantImages = imgsData.imgObjColorData.getSortedImagesByColor("Red");
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
        

    }

}