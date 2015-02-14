namespace PortableGrayMapTest.Reader
{
    using System;
    using System.IO;
    using NUnit.Framework;
    using PortableGrayMap;
    using PortableGrayMap.Reader;

    [TestFixture]
    public class P1ReaderTest
    {
        [SetUp]
        public void Setup()
        {
            _reader = new P1Reader();
        }

        private const string PathToSampleFolder = @"../../../Sources/Samples/P1/";

        private IPortbaleMapReader<IPortbaleBitmap, bool> _reader;

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void CheckMagicNumber()
        {
            _reader.ReadFromFile(Path.Combine(PathToSampleFolder, "../P4/", "feed.pbm"));
        }

        [Test]
        public void CheckSizeOfSampleCircle()
        {
            var image = _reader.ReadFromFile(Path.Combine(PathToSampleFolder, "circle.ascii.pbm"));

            Assert.AreEqual(200, image.Width, "Width");
            Assert.AreEqual(200, image.Height, "Height");
            Assert.IsNotNull(image.Pixels, "Pixels");
            Assert.AreEqual(40000, image.Pixels.Length, "Number of Pixels");
            //test some pixels
            Assert.IsFalse(image.Pixels[0]);
            Assert.IsFalse(image.Pixels[29*200 + 99]);
            Assert.IsTrue(image.Pixels[30*200 + 99]);
            Assert.IsTrue(image.Pixels[35*200 + 99]);
            Assert.IsFalse(image.Pixels[36*200 + 99]);
            Assert.IsFalse(image.Pixels[199*200 + 199]);
        }

        [Test]
        public void CheckImageWithMultilineComments()
        {
            var image = _reader.ReadFromFile(Path.Combine(PathToSampleFolder, "circleMultiLineComment.ascii.pbm"));

            Assert.AreEqual(200, image.Width, "Width");
            Assert.AreEqual(200, image.Height, "Height");
            Assert.IsNotNull(image.Pixels, "Pixels");
            Assert.AreEqual(40000, image.Pixels.Length, "Number of Pixels");
            //test some pixels
            Assert.IsFalse(image.Pixels[0]);
            Assert.IsFalse(image.Pixels[29*200 + 99]);
            Assert.IsTrue(image.Pixels[30*200 + 99]);
            Assert.IsTrue(image.Pixels[35*200 + 99]);
            Assert.IsFalse(image.Pixels[36*200 + 99]);
            Assert.IsFalse(image.Pixels[199*200 + 199]);
        }

        [Test]
        public void ReadTwoImagesFromOneFile()
        {
            IPortbaleBitmap image1, image2;
            using (
                var fileStream = new FileStream(Path.Combine(PathToSampleFolder, "circleWithSecondCircle.pbm"),
                    FileMode.Open))
            {
                image1 = _reader.ReadFromStream(fileStream);
                image2 = _reader.ReadFromStream(fileStream);
            }
            
            Assert.AreEqual(200, image1.Width, "Width of image1");
            Assert.AreEqual(200, image1.Height, "Height of image1");
            Assert.IsNotNull(image1.Pixels, "Pixels of image1");
            Assert.AreEqual(40000, image1.Pixels.Length, "Number of Pixels of image1");
            Assert.AreEqual(200, image2.Width, "Width of image2");
            Assert.AreEqual(200, image2.Height, "Height of image2");
            Assert.IsNotNull(image2.Pixels, "Pixels of image2");
            Assert.AreEqual(40000, image2.Pixels.Length, "Number of Pixels of image2");
            
        }
    }
}