<<<<<<< HEAD
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

namespace Photo_Rainbow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Main : Window
    {
        private static PhotoServiceManager p = new PhotoServiceManager();

        public Main()
        {
            InitializeComponent();           
            FlickrManager f = new FlickrManager();            
            p.LoadManager(f);
        }

        private void Auth_Button_Click(object sender, RoutedEventArgs e)
        {
            p.Authenticate();

            FlickrManager f = (FlickrManager)p.Manager;

            if (f.url != null)
            {
                System.Diagnostics.Process.Start(f.url);
            }
        }

        private void Complete_Authentication_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(CodeText.Text))
            {
                MessageBox.Show("You must paste the verifier code into the textbox above.");
                return;
            }
            try
            {
                FlickrManager f = (FlickrManager)p.Manager;
                f.CompleteAuth(CodeText.Text);
                MessageBox.Show("User authenticated!");
                if (f.IsAuthenticated())
                {
                    List<Image> imgObjs = f.GetPhotos();                    
                    UserImageDisplay imageDisplay = new UserImageDisplay(imgObjs);
                    imageDisplay.LoadImages();
                    imageDisplay.Show();
                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        
    }
}
=======
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

namespace Photo_Rainbow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Main : Window
    {
        private static PhotoServiceManager p = new PhotoServiceManager();

        public Main()
        {
            InitializeComponent();

            FlickrManager f = new FlickrManager();            
            p.LoadManager(f);
        }

        private void Authenticate_Click(object sender, RoutedEventArgs e)
        {
            p.Authenticate();

            FlickrManager f = (FlickrManager)p.Manager;

            if (f.url != null)
            {
                System.Diagnostics.Process.Start(f.url);
            }
        }

        private void Complete_Auth_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(CodeText.Text))
            {
                MessageBox.Show("You must paste the verifier code into the textbox above.");
                return;
            }
            try
            {
                FlickrManager f = (FlickrManager)p.Manager;
                f.CompleteAuth(CodeText.Text);
                MessageBox.Show("User authenticated!");
                if (f.IsAuthenticated())
                {
                    List<Image> imgObjs = f.GetPhotos();
                    ImageAnalyzer procImages = new ImageAnalyzer(imgObjs);
                }                         
            }            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
>>>>>>> upstream1/ayesha_dev
