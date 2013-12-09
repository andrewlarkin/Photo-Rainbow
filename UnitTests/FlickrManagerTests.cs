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
        private static Mock<FlickrManager> fMock;

        [SetUp]
        public void Init()
        {
            f = new FlickrManager();
            fMock = new Mock<FlickrManager>();
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

    //    [Test]
    //    public void CompleteAuthTest()
    //    {
    //        fMock.Verify(ff => ff.Authenticate(), Times.AtLeastOnce());
    //        Assert.IsTrue(f.IsAuthenticated());
    //    }

    //    [Test]
    //    public void GetPhotosTest()
    //    {
    //        Assert.IsNotNull(f.GetPhotos());
    //    }
    }
}
