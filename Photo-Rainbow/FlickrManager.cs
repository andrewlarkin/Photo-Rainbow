using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlickrNet;

namespace Photo_Rainbow
{
    public class FlickrManager : IAPIManager
    {
        const string ApiKey = "6c24e7c523faa6feee78c696b8ea31e2";
        const string SharedSecret = "88b95e7cc030a4cf";
        public static Flickr flickrInstance;
        public string url;

        private OAuthRequestToken requestToken; 

        public FlickrManager()
        {
            flickrInstance = new Flickr(ApiKey, SharedSecret);
        }

        public void Authenticate()
        {
            requestToken = flickrInstance.OAuthGetRequestToken("oob");

            url = flickrInstance.OAuthCalculateAuthorizationUrl(requestToken.Token, AuthLevel.Write);

            Console.WriteLine(url);
        }

        public void CompleteAuth(string Code)
        {
            try
            {
                OAuthToken = flickrInstance.OAuthGetAccessToken(requestToken, Code);
            }
            catch (FlickrApiException ex)
            {
                //TODO: Need exception handling
            }
        }

        public Boolean IsAuthenticated()
        {
            return OAuthToken != null;
        }

        public static OAuthAccessToken OAuthToken
        {
            get
            {
                return Properties.Settings.Default.FlickrOAuthToken;
            }
            set
            {
                Properties.Settings.Default.FlickrOAuthToken = value;
                Properties.Settings.Default.Save();
            }
        }

        public void GetPhotos()
        {

        }

    }
}
