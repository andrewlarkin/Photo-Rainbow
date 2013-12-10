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
    /// Interaction logic for UserImageDisplay.xaml
    /// </summary>
    public partial class UserImageDisplay : Window
    {
        private ImageDataStore userImagesData;
        public UserImageDisplay(ImageDataStore userImagesData)
        {
            InitializeComponent();            
            this.userImagesData = userImagesData;
        }

        public UserImageDisplay()
        {
            InitializeComponent();
        }

        public void LoadImages()
        {            
            foreach (Image img in userImagesData.Images)
            {
                System.Windows.Controls.Image userImage = new System.Windows.Controls.Image();
                userImage.Height = 100;
                userImage.Width = 100;

                BitmapImage userImageSource = new BitmapImage();
                userImageSource.BeginInit();
                userImageSource.UriSource = new Uri(img.Url);
                userImageSource.EndInit();
                userImage.Source = userImageSource;

                ImagesBox.Items.Add(userImage);
            }
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Continue_Button_Click(object sender, RoutedEventArgs e)
        {
            options sortOption = new options(this.userImagesData);
            sortOption.Show();
            this.Close();
        }
    }
}
