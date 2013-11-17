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
    public partial class photoSelectionFromSet : Form
    {        
        private List<string> photoSetIDs;
        private Flickr flickrAuthInstance;
        private List<int> rowIndices;
        List<Bitmap> bitmapImages;
        private List<int> colIndices;
        public photoSelectionFromSet(List<string> _photoSetIDs, Flickr _flickrAuthInstance)
        {            
            rowIndices = new List<int>();
            colIndices = new List<int>();
            photoSetIDs = _photoSetIDs;
            bitmapImages = new List<Bitmap>();
            flickrAuthInstance = _flickrAuthInstance;
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

        //Photos from each photo set selected are added to the datagrid view of this class.
        private void photoSelectionFromSet_Load(object sender, EventArgs e)
        {            
            dataGridView1.Rows.Clear();            
            foreach (string photoSetID in photoSetIDs)
            {
                PhotosetPhotoCollection collectionFromPhotoSet = flickrAuthInstance.PhotosetsGetPhotos(photoSetID);
                foreach (Photo photo in collectionFromPhotoSet)
                {
                    dataGridView1.Rows.Add(photo.Title, photo.LargeUrl);                    
                }
            }            
        }
    }
}
