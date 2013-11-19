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
    public partial class userSetSelection : Form
    {
        private PhotosetCollection photoSets;
        private Flickr flickrAuthInstance;
        private List<int> rowIndices;
        private List<int> colIndices;
        public userSetSelection(PhotosetCollection _photoSets, Flickr _flickrAuthInstance)
        {
            photoSets = _photoSets;
            flickrAuthInstance = _flickrAuthInstance;
            rowIndices = new List<int>();
            colIndices = new List<int>();
            InitializeComponent();
        }

        //Photoset is the collection of user's own photos in a set
        //Details of Photosets in user account are added to data grid view.
        private void userSetSelection_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (photoSets.Count >= 1)
            {
                foreach (Photoset photoSet in photoSets)
                {
                    dataGridView1.Rows.Add(photoSet.Title, photoSet.PhotosetId, photoSet.NumberOfPhotos);
                }
            }
        }

        //user can select single or multiple rows.
        //But click on PhotoSetID column cells as of now.
        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndices.Add(e.RowIndex);
            colIndices.Add(e.ColumnIndex);
        }

        //On clicking "Next" PhotosetIDS selected from the data grid view are put into list and transferred to the other class
        //to help in the process of photos in photoset.
        private void Next_Click(object sender, EventArgs e)
        {            
            List<String> photoSetIDs = new List<string>();
            for (int index = 0; index < rowIndices.Count; index++)
            {
                photoSetIDs.Add(dataGridView1[colIndices[index], rowIndices[index]].Value.ToString());
            }
            photoSelectionFromSet pSFS = new photoSelectionFromSet(photoSetIDs, flickrAuthInstance);
            pSFS.Show();
        }
    }
}
