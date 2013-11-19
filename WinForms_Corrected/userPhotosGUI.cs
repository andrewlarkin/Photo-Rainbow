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
    public partial class userPhotosGUI : Form
    {
        private Flickr flickrAuthInstance;
        public userPhotosGUI(Flickr _flickrAuthInstance)
        {
            flickrAuthInstance = _flickrAuthInstance;
            InitializeComponent();
        }

        private void FromPhotoSet_Click(object sender, EventArgs e)
        {
            PhotosetCollection userPhotoSets = flickrAuthInstance.PhotosetsGetList();
            if (userPhotoSets.Count >= 1)
            {
                userSetSelection uSS = new userSetSelection(userPhotoSets, flickrAuthInstance);
                uSS.Show();
            }
            else
            {
                MessageBox.Show("Photo sets are not available for the user");
            }
        }

        private void FromGallery_Click(object sender, EventArgs e)
        {
            GalleryCollection userGalleryCollection = flickrAuthInstance.GalleriesGetList();
            if (userGalleryCollection.Count >= 1)
            {
                userGallerySelection uGS = new userGallerySelection(userGalleryCollection, flickrAuthInstance);
                uGS.Show();
            }
            else
            {
                MessageBox.Show("User don't have any gallaries in his/her account");
            }
        }

        private void FromPhotoStream_Click(object sender, EventArgs e)
        {
            PhotoCollection photoStreamPhotos = flickrAuthInstance.PeopleGetPhotos();
            if (photoStreamPhotos.Count >= 1)
            {
                photo userPhotos = new photo(photoStreamPhotos, flickrAuthInstance);
                userPhotos.Show();
            }
            else
            {
                MessageBox.Show("No Photos in user's photo stream");
            }
        }
    }
}
