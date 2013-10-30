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
//using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Drawing;

namespace Photo_Rainbow
{
    /// <summary>
    /// Interaction logic for ImageAnalysis.xaml
    /// </summary>
    public partial class ImageAnalysis : Window
    {
        public ImageAnalysis()
        {
            InitializeComponent();           
        }

        private Label label1 = new Label();
        private Label label2 = new Label();
        private Label label3 = new Label();
        private Label label4 = new Label();
        private Label label5 = new Label();
        private Label label6 = new Label();
        private Label label7 = new Label();
        private Label label8 = new Label();
        private Label label9 = new Label();
        private Label label10 = new Label();
        private Label label11 = new Label();
        private Label label12 = new Label();
        private Label label13 = new Label();
        private Label label14 = new Label();
        private Label label15 = new Label();
        private Label label16 = new Label();
        private Label label17 = new Label();
        private Label label18 = new Label();
        private Label label19 = new Label();
        private Label label20 = new Label();
        private Label label21 = new Label();
        private Label label22 = new Label();
        private Label label23 = new Label();


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                ImageColorData iCD = new ImageColorData();
                ImageAnalysis ia = new ImageAnalysis();
                Bitmap img = new Bitmap("C:\\Users\\Administrator\\Desktop\\1.jpg");
                //( new Uri("Images/1.jpg", UriKind.Relative).AbsolutePath);
                Dictionary<String, List<Color>> colorStructsOfImage = iCD.getColorsInImage(img);
                float avgBrightnessByColor = iCD.calcAverageBrightnessByColor("Yellow");
                float percentageOfColor = iCD.percentageOfColorInImage("Yellow");
                label8.Content = "PERCENTAGE BY COLOR";
                label1.Content = "Violet     " + iCD.percentageOfColorInImage("Violet").ToString();
                label2.Content = "Indigo     " + iCD.percentageOfColorInImage("Indigo").ToString();
                label3.Content = "Blue     " + iCD.percentageOfColorInImage("Blue").ToString();
                label4.Content = "Green     " + iCD.percentageOfColorInImage("Green").ToString();
                label5.Content = "Yellow     " + iCD.percentageOfColorInImage("Yellow").ToString();
                label6.Content = "Orange     " + iCD.percentageOfColorInImage("Orange").ToString();
                label7.Content = "Red     " + iCD.percentageOfColorInImage("Red").ToString();
                label9.Content = "BRIGHTNESS BY COLOR";
                label17.Content = "Violet     " + iCD.calcAverageBrightnessByColor("Violet").ToString();
                label18.Content = "Indigo     " + iCD.calcAverageBrightnessByColor("Indigo").ToString();
                label19.Content = "Blue     " + iCD.calcAverageBrightnessByColor("Blue").ToString();
                label20.Content = "Green     " + iCD.calcAverageBrightnessByColor("Green").ToString();
                label21.Content = "Yellow     " + iCD.calcAverageBrightnessByColor("Yellow").ToString();
                label22.Content = "Orange     " + iCD.calcAverageBrightnessByColor("Orange").ToString();
                label23.Content = "Red     " + iCD.calcAverageBrightnessByColor("Red").ToString();

                this.splMain.Children.Add(label8);
                this.splMain.Children.Add(label1);
                this.splMain.Children.Add(label2);
                this.splMain.Children.Add(label3);
                this.splMain.Children.Add(label4);
                this.splMain.Children.Add(label5);
                this.splMain.Children.Add(label6);
                this.splMain.Children.Add(label7);
                this.splMain.Children.Add(label9);
                this.splMain.Children.Add(label17);
                this.splMain.Children.Add(label18);
                this.splMain.Children.Add(label19);
                this.splMain.Children.Add(label20);
                this.splMain.Children.Add(label21);
                this.splMain.Children.Add(label22);
                this.splMain.Children.Add(label23);

            }

            catch (Exception ee)
            {

            }

        }
        
    }
}
