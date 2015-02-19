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
    public class P5ReaderTest
    {
        [SetUp]
        public void Setup()
        {
            _reader = new P5Reader();
        }

        private const string PathToSampleFolder = @"../../../Sources/Samples/P5/";

        private IPortbaleMapReader<IPortableGraymap, ushort> _reader;

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckMagicNumber()
        {
            _reader.ReadFromFile(Path.Combine(PathToSampleFolder, "../P2/", "lena.ascii.pgm"));
        }

        [Test]
        public void CheckSizeOfSampleCircle()
        {
            var image = _reader.ReadFromFile(Path.Combine(PathToSampleFolder, "bird.pgm"));

            Assert.AreEqual(321, image.Width, "Width");
            Assert.AreEqual(481, image.Height, "Height");
            Assert.AreEqual(255, image.MaxValue, "MaxValue");
            Assert.IsNotNull(image.Pixels, "Pixels");
            Assert.AreEqual(321*481, image.Pixels.Length, "Number of Pixels");
            //test some pixels
            Assert.AreEqual(52, image.Pixels[0], "Pixel 0");
            Assert.AreEqual(139, image[87,294], "Pixel [87,294]");
            Assert.AreEqual(65, image[87, 295], "Pixel [87,295]");
            Assert.AreEqual(133, image[87, 296], "Pixel [87,296]");
        }

        [Test]
        public void CrossCheckWithP2Reader()
        {
            var imageFromP4Reader = _reader.ReadFromFile(Path.Combine(PathToSampleFolder, "lena.pgm"));
            var imageFromP2Reader =
                new P2Reader().ReadFromFile(Path.Combine(PathToSampleFolder, "../P2/", "lena.ascii.pgm"));

            Assert.AreEqual(imageFromP2Reader.Width, imageFromP4Reader.Width, "Width");
            Assert.AreEqual(imageFromP2Reader.Height, imageFromP4Reader.Height, "Height");
            for (var y = 0; y < 481; y++)
            {
                for (var x = 0; x < 321; x++)
                {
                    Assert.AreEqual(imageFromP2Reader[x, y], imageFromP4Reader[x, y], "Pixel {0}/{1}".FormatWith(x, y));
                }
            }
        }
    }
}
