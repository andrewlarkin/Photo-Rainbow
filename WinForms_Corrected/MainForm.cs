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
    public partial class MainForm : Form
    {
        public static Flickr flickrAccessInstance;
        public MainForm()
        {
            InitializeComponent();
        }
                      
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AuthForm _authForm = new AuthForm();
            _authForm.Show(); 
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PhotoSearchForm form = new PhotoSearchForm();
            form.ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {           
            if (FlickrManager.OAuthToken == null || FlickrManager.OAuthToken.Token == null)
            {
                MessageBox.Show("You must authenticate before you can upload a photo.");
                return;
            }

            UploadForm form = new UploadForm();
            form.ShowDialog();        

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (flickrAccessInstance.OAuthAccessToken == null)
            {
                MessageBox.Show("You must authenticate before you can use GetPhotos functionality.");
                return;
            }
            userPhotosGUI _uPGUI = new userPhotosGUI(flickrAccessInstance);
            _uPGUI.Show();
        }
    }
}
