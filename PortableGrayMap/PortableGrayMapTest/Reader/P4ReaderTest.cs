namespace PortableGrayMapTest.Reader
{
    using System;
    using System.IO;
    using NUnit.Framework;
    using PortableGrayMap;
    using PortableGrayMap.Reader;
    using Tanpohp.Extensions;

    [TestFixture]
    public class P4ReaderTest
    {
        [SetUp]
        public void Setup()
        {
            _reader = new P4Reader();
        }

        private const string PathToSampleFolder = @"../../../Sources/Samples/P4/";

        private IPortableBitmapReader _reader;

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void CheckMagicNumber()
        {
            _reader.ReadFromFile(Path.Combine(PathToSampleFolder, "../P1/", "feep.ascii.pbm"));
        }

        [Test]
        public void CheckSizeOfSampleCircle()
        {
            var image = _reader.ReadFromFile(Path.Combine(PathToSampleFolder, "circle.pbm"));

            Assert.AreEqual(200, image.Width, "Width");
            Assert.AreEqual(200, image.Height, "Height");
            Assert.IsNotNull(image.Pixels, "Pixels");
            Assert.AreEqual(40000, image.Pixels.Length, "Number of Pixels");
            //test some pixels
            Assert.IsFalse(image.Pixels[0], "Pixel 0");
            Assert.IsFalse(image.Pixels[29*200 + 99], "Pixel 29*200+99");
            Assert.IsTrue(image.Pixels[30*200 + 99], "Pixel 30*200+99");
            Assert.IsTrue(image.Pixels[35*200 + 99], "Pixel 35*200+99");
            Assert.IsFalse(image.Pixels[36*200 + 99], "Pixel 36*200+99");
            Assert.IsFalse(image.Pixels[199*200 + 199], "Pixel 199*200+99");
        }

        [Test]
        public void CrossCheckWithP1Reader()
        {
            var imageFromP4Reader = _reader.ReadFromFile(Path.Combine(PathToSampleFolder, "circle.pbm"));
            var imageFromP1Reader =
                new P1Reader().ReadFromFile(Path.Combine(PathToSampleFolder, "../P1/", "circle.ascii.pbm"));

            Assert.AreEqual(imageFromP1Reader.Width, imageFromP4Reader.Width, "Width");
            Assert.AreEqual(imageFromP1Reader.Height, imageFromP4Reader.Height, "Height");
            for (var y = 0; y < 200; y++)
            {
                for (var x = 0; x < 200; x++)
                {
                    Assert.AreEqual(imageFromP1Reader[x, y], imageFromP4Reader[x, y], "Pixel {0}/{1}".FormatWith(x, y));
                }
            }
        }
    }
}