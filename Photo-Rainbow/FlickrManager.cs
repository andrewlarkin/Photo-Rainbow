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
        public string url;


        private static Flickr instance;
        private OAuthRequestToken requestToken; 

        public FlickrManager()
        {
            Instance = new Flickr(ApiKey, SharedSecret);
        }

        public void Authenticate()
        {
            requestToken = Instance.OAuthGetRequestToken("oob");

            url = Instance.OAuthCalculateAuthorizationUrl(requestToken.Token, AuthLevel.Write);
        }

        public void CompleteAuth(string Code)
        {
            try
            {
                OAuthToken = Instance.OAuthGetAccessToken(requestToken, Code);
            }
            catch (FlickrApiException ex)
            {
                Console.WriteLine(ex.Message);
                //TODO: Need exception handling
            }
        }

        public Boolean IsAuthenticated()
        {
            return OAuthToken != null;
        }

        public Flickr Instance
        {
            set { instance = value; }
            get { return instance; }
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

        public List<Image> GetPhotos()
        {
            List<Image> images = new List<Image>();

            PhotoCollection photocollection = Instance.PeopleGetPhotos("me");

            foreach (Photo p in photocollection)
            {
                if (p.OriginalUrl != null)
                {
                    images.Add(new Image(p.OriginalUrl));
                }
            }

            return images;
        }

    }
}
