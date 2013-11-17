using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlickrNet;

namespace WinForms
{
    class photoDownload
    {
        public PhotosetPhotoCollection getPhotosFromPhotoSet()
        {
            Flickr _flickr = FlickrManager.GetInstance();
            PhotosetPhotoCollection userPhotosFromSet = _flickr.PhotosetsGetPhotos("72157637727311424");
            return userPhotosFromSet;
        }
    }
}
