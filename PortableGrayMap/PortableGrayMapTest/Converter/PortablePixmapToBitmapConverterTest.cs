namespace PortableGrayMapTest.Converter
{
    using System.Drawing;
    using NUnit.Framework;
    using PortableGrayMap;
    using PortableGrayMap.Converter;
    using Tanpohp.Extensions;

    [TestFixture]
    public class PortablePixmapToBitmapConverterTest
    {
        [SetUp]
        public void Setup()
        {
            _convert = new PortablePixmapToBitmapConverter();

            _singleLineColorRamp = new PortablePixmap(17, 1, new RgbPixel[17], 17);
            for (byte x = 0; x < 17; x++) _singleLineColorRamp[x, 0] = new RgbPixel(x, (byte) (17 - x), 0);
        }

        private IPortablePixmap _singleLineColorRamp;

        private IConverter<IPortablePixmap, Bitmap> _convert;

        [Test]
        public void TestWithSingleLineColorRamp()
        {
            var bitmap = _convert.Convert(_singleLineColorRamp);

            AssertAreEqual(new RgbPixel(0, 255, 0), bitmap.GetPixel(0, 0), 0, 0);
            AssertAreEqual(new RgbPixel(15, 240, 0), bitmap.GetPixel(1, 0), 1, 0);
            AssertAreEqual(new RgbPixel(30, 225, 0), bitmap.GetPixel(2, 0), 2, 0);
            AssertAreEqual(new RgbPixel(45, 210, 0), bitmap.GetPixel(3, 0), 3, 0);
            AssertAreEqual(new RgbPixel(60, 195, 0), bitmap.GetPixel(4, 0), 4, 0);
            AssertAreEqual(new RgbPixel(75, 180, 0), bitmap.GetPixel(5, 0), 5, 0);
            AssertAreEqual(new RgbPixel(90, 165, 0), bitmap.GetPixel(6, 0), 6, 0);
            AssertAreEqual(new RgbPixel(105, 150, 0), bitmap.GetPixel(7, 0), 7, 0);
            AssertAreEqual(new RgbPixel(120, 135, 0), bitmap.GetPixel(8, 0), 8, 0);
            AssertAreEqual(new RgbPixel(135, 120, 0), bitmap.GetPixel(9, 0), 9, 0);
            AssertAreEqual(new RgbPixel(150, 105, 0), bitmap.GetPixel(10, 0), 10, 0);
            AssertAreEqual(new RgbPixel(165, 90, 0), bitmap.GetPixel(11, 0), 11, 0);
            AssertAreEqual(new RgbPixel(180, 75, 0), bitmap.GetPixel(12, 0), 12, 0);
            AssertAreEqual(new RgbPixel(195, 60, 0), bitmap.GetPixel(13, 0), 13, 0);
            AssertAreEqual(new RgbPixel(210, 45, 0), bitmap.GetPixel(14, 0), 14, 0);
            AssertAreEqual(new RgbPixel(225, 30, 0), bitmap.GetPixel(15, 0), 15, 0);
            AssertAreEqual(new RgbPixel(240, 15, 0), bitmap.GetPixel(16, 0), 16, 0);
        }

        private static void AssertAreEqual(RgbPixel expected, Color actual, int x, int y)
        {
            Assert.AreEqual(255, actual.A, "Alpha {0}/{1}".FormatWith(x,y));
            Assert.AreEqual(expected.Red, actual.R, "Red {0}/{1}".FormatWith(x, y));
            Assert.AreEqual(expected.Green, actual.G, "Green {0}/{1}".FormatWith(x, y));
            Assert.AreEqual(expected.Blue, actual.B, "Blue {0}/{1}".FormatWith(x, y));
        }
    }
}