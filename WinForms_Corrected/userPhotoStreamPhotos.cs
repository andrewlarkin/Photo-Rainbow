using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FlickrNet;
using System.Net;

namespace WinForms
{
    public partial class photo : Form
    {
        private PhotoCollection userPhotoStreamPhotos;
        private Flickr flickrAuthInstance;
        private List<Bitmap> bitmapImages;
        public photo(PhotoCollection _photos, Flickr _flickrAuthInstance)
        {
            userPhotoStreamPhotos = _photos;
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

        private void photo_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (userPhotoStreamPhotos.Count >= 1)
            {
                foreach (Photo photo in userPhotoStreamPhotos)
                {
                    dataGridView1.Rows.Add(photo.Title, photo.LargeUrl);
                }
            }
        }
    }
}
