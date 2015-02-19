namespace PortableGrayMapTest.Reader
{
    using System;
    using System.IO;
    using NUnit.Framework;
    using PortableGrayMap;
    using PortableGrayMap.Reader;

    [TestFixture]
    public class P2ReaderTest
    {
        [SetUp]
        public void Setup()
        {
            _reader = new P2Reader();
        }

        private const string PathToSampleFolder = @"../../../Sources/Samples/P2/";

        private IPortableGraymapReader _reader;

        [Test]
        public void CheckImageWithMultilineComments()
        {
            var image = _reader.ReadFromFile(Path.Combine(PathToSampleFolder, "lenaWithComments.ascii.pgm"));

            Assert.AreEqual(512, image.Width, "Width");
            Assert.AreEqual(512, image.Height, "Height");
            Assert.IsNotNull(image.Pixels, "Pixels");
            Assert.AreEqual(512*512, image.Pixels.Length, "Number of Pixels");
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void CheckMagicNumber()
        {
            _reader.ReadFromFile(Path.Combine(PathToSampleFolder, "../P4/", "feed.pbm"));
        }

        [Test]
        public void CheckMetaDataOfSampleLena()
        {
            var image = _reader.ReadFromFile(Path.Combine(PathToSampleFolder, "lena.ascii.pgm"));

            Assert.AreEqual(512, image.Width, "Width");
            Assert.AreEqual(512, image.Height, "Height");
            Assert.IsNotNull(image.Pixels, "Pixels");
            Assert.AreEqual(512 * 512, image.Pixels.Length, "Number of Pixels");
            Assert.AreEqual(245, image.MaxValue);
        }

        [Test]
        public void CheckPixelOfSampleLena()
        {
            var image = _reader.ReadFromFile(Path.Combine(PathToSampleFolder, "lena.ascii.pgm"));

            Assert.AreEqual(200, image[238,266]);//gray 208 -> 199.84
            Assert.AreEqual(189, image[239, 266]);//gray 196 -> 188.31 // I don't know why thisis 189 instead of 188
            Assert.AreEqual(122, image[240, 266]);//gray 127 -> 122.01
            Assert.AreEqual(80, image[241, 266]);//gray 83 -> 79.74
            Assert.AreEqual(91, image[242, 266]);//gray 95 -> 91.27
        }

        [Test]
        public void ReadTwoImagesFromOneFile()
        {
            IPortableGraymap image1, image2;
            using (
                var fileStream = new FileStream(Path.Combine(PathToSampleFolder, "lenaTwice.pgm"),
                    FileMode.Open))
            {
                image1 = _reader.ReadFromStream(fileStream);
                image2 = _reader.ReadFromStream(fileStream);
            }

            Assert.AreEqual(512, image1.Width, "Width of image1");
            Assert.AreEqual(512, image1.Height, "Height of image1");
            Assert.IsNotNull(image1.Pixels, "Pixels of image1");
            Assert.AreEqual(512*512, image1.Pixels.Length, "Number of Pixels of image1");
            Assert.AreEqual(512, image2.Width, "Width of image2");
            Assert.AreEqual(512, image2.Height, "Height of image2");
            Assert.IsNotNull(image2.Pixels, "Pixels of image2");
            Assert.AreEqual(512*512, image2.Pixels.Length, "Number of Pixels of image2");
        }
    }
}