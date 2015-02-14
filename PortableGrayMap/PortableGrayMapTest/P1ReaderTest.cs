namespace PortableGrayMapTest
{
    using System;
    using System.IO;
    using NUnit.Framework;
    using PortableGrayMap;

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
        public void IndexerGet()
        {
            var image = _reader.ReadFromFile(Path.Combine(PathToSampleFolder, "circle.ascii.pbm"));

            Assert.AreEqual(image[0, 0], image.Pixels[0], "1st");
            Assert.AreEqual(image[29, 99], image.Pixels[99 * 200 + 29], "2nd");
            Assert.AreEqual(image[30, 99], image.Pixels[99 * 200 + 30], "3th");
            Assert.AreEqual(image[35, 99], image.Pixels[99 * 200 + 35], "4th");
        }
    }
}