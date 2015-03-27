namespace PortableGrayMapTest.Converter
{
    using System.Windows.Media.Imaging;
    using NUnit.Framework;
    using PortableGrayMap;
    using PortableGrayMap.Converter;
    using Tanpohp.Extensions;

    [TestFixture]
    public class PortableGraymapToBitmapSourceConverterTest
    {
        [SetUp]
        public void Setup()
        {
            _convert = new PortableGraymapToBitmapSourceConverter();

            _singleLineColorRamp = new PortableGraymap(17, 1, new ushort[17], 17);
            for (var x = 0; x < 17; x++) _singleLineColorRamp[x, 0] = (ushort) x;
        }

        private IPortableGraymap _singleLineColorRamp;

        private IConverter<IPortableGraymap, BitmapSource> _convert;

        [Test]
        public void TestWithSingleLineColorRamp()
        {
            var bitmapSource = _convert.Convert(_singleLineColorRamp);
            var bitmap = bitmapSource.ConvertToBitmap();

            for (var x = 0; x < 17; x++)
            {
                var pixel = bitmap.GetPixel(x, 0);
                Assert.AreEqual(255, pixel.A, "Alpha {0}/{1}".FormatWith(x, 0));
                Assert.AreEqual(255 - x*15, pixel.R, "Red {0}/{1}".FormatWith(x, 0));
                Assert.AreEqual(255 - x*15, pixel.G, "Green {0}/{1}".FormatWith(x, 0));
                Assert.AreEqual(255 - x*15, pixel.B, "Blue {0}/{1}".FormatWith(x, 0));
            }
        }
    }
}