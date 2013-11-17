using System;
using System.Net;
using System.Windows;
using FlickrNet;

namespace WinForms
{
    public class FlickrManager
    {
        public const string ApiKey = "6c24e7c523faa6feee78c696b8ea31e2";
        public const string SharedSecret = "88b95e7cc030a4cf";

        public static Flickr GetInstance()
        {
            return new Flickr(ApiKey, SharedSecret);
        }

        public static Flickr GetAuthInstance()
        {
            var f = new Flickr(ApiKey, SharedSecret);
            f.OAuthAccessToken = OAuthToken.Token;
            f.OAuthAccessTokenSecret = OAuthToken.TokenSecret;
            return f;
        }

        public static OAuthAccessToken OAuthToken
        {
            get
            {
                return Properties.Settings.Default.OAuthToken;
            }
            set
            {
                Properties.Settings.Default.OAuthToken = value;
                Properties.Settings.Default.Save();
            }
        }

    }
}
