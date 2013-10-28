using System;


namespace UnitTests
{
    using NUnit.Framework;
    using Photo_Rainbow;

    [TestFixture]
    public class FlickrManagerTests
    {
        [Test]
        public void IsInstanceOfIAPIManager()
        {
            FlickrManager f = new FlickrManager();
            Assert.IsInstanceOf<IAPIManager>(f);
        }

        [Test]
        public void AuthenticationTest()
        {
            FlickrManager f = new FlickrManager();
            f.Authenticate();

            Assert.IsNotNull(f.url);
        }

        [Test]
        public void CompleteAuthTest()
        {
            //TODO: not sure how to test this, since Code is required
        }
    }
}
