namespace PortableGrayMapTest.Reader
{
    using System.IO;
    using NUnit.Framework;
    using PortableGrayMap;
    using PortableGrayMap.Reader;
    using Tanpohp.Extensions;

    [TestFixture]
    internal class P3ReaderTest
    {
        [SetUp]
        public void Setup()
        {
            _reader = new P3Reader();
        }

        private const string PathToSampleFolder = @"../../../Sources/Samples/P3/";

        private IPortablePixmapReader _reader;

        [Test]
        public void CheckImageContent()
        {
            var pixels = new[]
            {
                new RgbPixel(0), new RgbPixel(0), new RgbPixel(0), new RgbPixel(15, 0, 15),
                new RgbPixel(0), new RgbPixel(0, 15, 7), new RgbPixel(0), new RgbPixel(0),
                new RgbPixel(0), new RgbPixel(0), new RgbPixel(0, 15, 7), new RgbPixel(0),
                new RgbPixel(15, 0, 15), new RgbPixel(0), new RgbPixel(0), new RgbPixel(0)
            };

            var image = _reader.ReadFromFile(Path.Combine(PathToSampleFolder, "feep.ascii.ppm"));

            for (var y = 0; y < 4; y++)
            {
                for (var x = 0; x < 4; x++)
                {
                    Assert.AreEqual(pixels[x + y*4].Red, image[x, y].Red, "Pixel[{0},{1}].Red".FormatWith(x, y));
                }
            }
        }

        [Test]
        public void CheckImageProperties()
        {
            var image = _reader.ReadFromFile(Path.Combine(PathToSampleFolder, "feep.ascii.ppm"));

            Assert.AreEqual(4, image.Width, "Width");
            Assert.AreEqual(4, image.Height, "Height");
            Assert.AreEqual(15, image.MaxValue, "MaxValue");
            Assert.IsNotNull(image.Pixels, "Pixels");
            Assert.AreEqual(16, image.Pixels.Length, "Number of Pixels");
        }
    }
}