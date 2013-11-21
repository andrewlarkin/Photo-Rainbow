using System;


namespace UnitTests
{
    using NUnit.Framework;
    using Photo_Rainbow;
    using Moq;
    using FlickrNet;

    [TestFixture]
    public class FlickrManagerTests
    {
        private static FlickrManager f;
        private static Mock<Flickr> flickrMock;

        [SetUp]
        public void Init()
        {
            f = new FlickrManager();
        }

        [Test]
        public void IsInstanceOfIAPIManager()
        {
            Assert.IsInstanceOf<IAPIManager>(f);
        }

        [Test]
        public void SetsFlickrInstance()
        {
            Assert.IsInstanceOf<Flickr>(f.Instance);
        }

        [Test]
        public void AuthenticationTest()
        {
            f.Authenticate();

            Assert.IsNotNull(f.url);
        }

        [Test]
        public void CompleteAuthTest()
        {
            //TODO: figure out how to test this
        }

        [Test]
        public void GetPhotosTest()
        {
            //TODO: figure out how to test this 
        }
    }
}
