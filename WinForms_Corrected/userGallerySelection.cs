using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FlickrNet;

namespace WinForms
{
    public partial class userGallerySelection : Form
    {
        private GalleryCollection userGalleryCollection;
        private Flickr flickrAuthInstance;
        private List<int> rowIndices;
        private List<int> colIndices;
        public userGallerySelection(GalleryCollection _userGalleryCollection, Flickr _flickrAuthInstance)
        {
            userGalleryCollection = _userGalleryCollection;
            flickrAuthInstance = _flickrAuthInstance;
            rowIndices = new List<int>();
            colIndices = new List<int>();
            InitializeComponent();
        }

        //Users please click GalleryID column of data grid view.
        //User can select single column or multiple columns.
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndices.Add(e.RowIndex);
            colIndices.Add(e.ColumnIndex);
        }

        //Galleries in the user account are loaded into the datagrid view of this class.
        //Galleries are the collection of photos of other users selected by our user.
        private void userGallerySelection_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (userGalleryCollection.Count >= 1)
            {
                foreach (Gallery userGallery in userGalleryCollection)
                {
                    dataGridView1.Rows.Add(userGallery.Title, userGallery.GalleryId, userGallery.PhotosCount);
                }
            }
        }

        //When the user clicks "Next" Button list of galleryids selected by user in the data grid view will be transferred to another class to help the process of photos in gallery
        private void Next_Click(object sender, EventArgs e)
        {
            List<String> galleryIDs = new List<string>();
            for (int index = 0; index < rowIndices.Count; index++)
            {
                galleryIDs.Add(dataGridView1[colIndices[index], rowIndices[index]].Value.ToString());
            }            
            photoSelectionFromGallery pSFG = new photoSelectionFromGallery(galleryIDs, flickrAuthInstance);
            pSFG.Show();
        }
    }
}
