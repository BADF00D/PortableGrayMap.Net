namespace PortableGrayMapTest
{
    using System;
    using System.IO;
    using NUnit.Framework;
    using PortableGrayMap;

    [TestFixture]
    public class P1ReaderTest
    {
        private const string PathToSampleFolder = @"../../../Sources/Samples/P1/";

        [SetUp]
        public void Setup()
        {
            _reader = new P1Reader();
        }

        private IPortbaleMapReader<IPortbaleBitmap, bool> _reader;

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
            Assert.IsFalse(image.Pixels[29 * 200 + 99]);
            Assert.IsTrue(image.Pixels[30 * 200 + 99]);
            Assert.IsTrue(image.Pixels[35 * 200 + 99]);
            Assert.IsFalse(image.Pixels[36 * 200 + 99]);
            Assert.IsFalse(image.Pixels[199*200+199]);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckmagicNumber()
        {
            _reader.ReadFromFile(Path.Combine(PathToSampleFolder, "../P4/", "feed.pbm"));
        }
    }
}