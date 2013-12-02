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
        private static Mock<FlickrManager> fMock;
        private static Mock<ImageColorData> colorRange;

        [SetUp]
        public void Init()
        {
            f = new FlickrManager();
            colorRange = new Mock<ImageColorData>();
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
            fMock.Verify(ff => ff.Authenticate(), Times.AtLeastOnce());
            Assert.IsTrue(f.IsAuthenticated());
        }

        [Test]
        public void GetPhotosTest()
        {
            Assert.IsNotNull(f.GetPhotos());
        }

        [Test]
        public void isViolet()
        {
            colorRange.Verify(m => m.colorKeyPixValue.Keys.Equals("Violet") && m.colorKeyPixValue["Violet"][0] >= 300.0 && m.colorKeyPixValue["Violet"][m.colorKeyPixValue["Violet"].Count - 1] <= 360.0);
        }
        [Test]
        public void isIndigo()
        {
            colorRange.Verify(m => m.colorKeyPixValue.Keys.Equals("Indigo") && m.colorKeyPixValue["Indigo"][0] >= 275.0 && m.colorKeyPixValue["Indigo"][m.colorKeyPixValue["Indigo"].Count - 1] <= 299.0);
        }

        [Test]
        public void isBlue()
        {
            colorRange.Verify(m => m.colorKeyPixValue.Keys.Equals("Blue") && m.colorKeyPixValue["Blue"][0] >= 240.0 && m.colorKeyPixValue["Blue"][m.colorKeyPixValue["Blue"].Count - 1] <= 274.0);
        }

        [Test]
        public void isGreen()
        {
            colorRange.Verify(m => m.colorKeyPixValue.Keys.Equals("Green") && m.colorKeyPixValue["Green"][0] >= 120.0 && m.colorKeyPixValue["Green"][m.colorKeyPixValue["Green"].Count - 1] <= 239.0);
        }

        [Test]
        public void isYellow()
        {
            colorRange.Verify(m => m.colorKeyPixValue.Keys.Equals("Yellow") && m.colorKeyPixValue["Yellow"][0] >= 60.0 && m.colorKeyPixValue["Yellow"][m.colorKeyPixValue["Yellow"].Count - 1] <= 119.0);
        }

        [Test]
        public void isOrange()
        {
            colorRange.Verify(m => m.colorKeyPixValue.Keys.Equals("Orange") && m.colorKeyPixValue["Orange"][0] >= 40.0 && m.colorKeyPixValue["Orange"][m.colorKeyPixValue["Orange"].Count - 1] <= 59.0);

        }
        [Test]
        public void isRed()
        {
            colorRange.Verify(m => m.colorKeyPixValue.Keys.Equals("Red") && m.colorKeyPixValue["Red"][0] >= 0.0 && m.colorKeyPixValue["Red"][m.colorKeyPixValue["Red"].Count - 1] <= 39.0);
        }
    }
}
