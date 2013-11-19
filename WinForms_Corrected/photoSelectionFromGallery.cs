using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using FlickrNet;

namespace WinForms
{
    public partial class photoSelectionFromGallery : Form
    {        
        List<string> galleryIDs;
        List<Bitmap> bitmapImages;
        private Flickr flickrAuthInstance;
        public photoSelectionFromGallery(List<string> _galleryIDs, Flickr _flickrAuthInstance)
        {
            galleryIDs = _galleryIDs;
            flickrAuthInstance = _flickrAuthInstance;
            bitmapImages = new List<Bitmap>();
            InitializeComponent();
        }

        //User can click single row or multiple rows in data grid view. But as of now do even the multiple clicks only PhotoURL column
        //No of bitmap images got from the flickr will be displayed in message box
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Image imageFromStream = null;
                Bitmap bitmapImage;
                string imageURL = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
                HttpWebRequest requestForImage = (System.Net.HttpWebRequest)HttpWebRequest.Create(imageURL);
                HttpWebResponse flickrImageAsResponse = (System.Net.HttpWebResponse)requestForImage.GetResponse();
                imageFromStream = Image.FromStream(flickrImageAsResponse.GetResponseStream());
                bitmapImage = new Bitmap(imageFromStream);
                bitmapImages.Add(bitmapImage);
                flickrImageAsResponse.Close();
                MessageBox.Show("BitMapImageCount:" + bitmapImages.Count);
            }
            catch (Exception ae)
            {
                ae.ToString();
            }
        }

        //Photos from each gallery selected are added to the datagrid view of this class.
        private void photoSelectionFromGallery_Load(object sender, EventArgs e)
        {            
            dataGridView1.Rows.Clear();
            foreach (string galleryID in galleryIDs)
            {
                GalleryPhotoCollection collectionFromGallery = flickrAuthInstance.GalleriesGetPhotos(galleryID);
                foreach (Photo photo in collectionFromGallery)
                {
                    dataGridView1.Rows.Add(photo.Title, photo.LargeUrl);                    
                }
            }             
        }
    }
}
