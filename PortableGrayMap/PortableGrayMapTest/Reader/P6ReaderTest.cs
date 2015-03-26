using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortableGrayMapTest.Reader
{
    using System.IO;
    using NUnit.Framework;
    using PortableGrayMap;
    using PortableGrayMap.Reader;
    using Tanpohp.Extensions;

    [TestFixture]
    public class P6ReaderTest
    {
        [SetUp]
        public void Setup()
        {
            _reader = new P6Reader();
        }

        private const string PathToSampleFolder = @"../../../Sources/Samples/P6/";

        private IPortablePixmapReader _reader;

        [Test]
        public void CheckImageContent()
        {
            var image = _reader.ReadFromFile(Path.Combine(PathToSampleFolder, "pbmlib.ppm"));

            Assert.AreEqual(255, image[0, 0].Red, "Pixel[0,0].Red");
            Assert.AreEqual(0, image[0, 0].Green, "Pixel[0,0].Green");
            Assert.AreEqual(0, image[0, 0].Blue, "Pixel[0,0].Blue");

            Assert.AreEqual(0, image[14, 4].Red, "Pixel[14,4].Red");
            Assert.AreEqual(62, image[14, 4].Green, "Pixel[14,4].Green");
            Assert.AreEqual(50, image[14, 4].Blue, "Pixel[14,4].Blue");

            Assert.AreEqual(0, image[10, 9].Red, "Pixel[10,9].Red");
            Assert.AreEqual(255, image[10, 9].Green, "Pixel[10,9].Green");
            Assert.AreEqual(0, image[10, 9].Blue, "Pixel[01,9].Blue");

            
        }

        [Test]
        public void CheckImageProperties()
        {
            var image = _reader.ReadFromFile(Path.Combine(PathToSampleFolder, "pbmlib.ppm"));

            Assert.AreEqual(20, image.Width, "Width");
            Assert.AreEqual(10, image.Height, "Height");
            Assert.AreEqual(255, image.MaxValue, "MaxValue");
            Assert.IsNotNull(image.Pixels, "Pixels");
            Assert.AreEqual(200, image.Pixels.Length, "Number of Pixels");
        }
    }
}
