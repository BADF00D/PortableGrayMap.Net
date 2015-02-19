namespace PortableGrayMapTest.Converter
{
    using System.Drawing;
    using System.IO;
    using System.Windows.Media.Imaging;
    using NUnit.Framework;
    using PortableGrayMap;
    using PortableGrayMap.Converter;
    using Tanpohp.Extensions;

    [TestFixture]
    public class PortableBitmapToBitmapSourceConverterTest
    {
        [SetUp]
        public void Setup()
        {
            _converter = new PortableBitmapToBitmapSourceConverter();

            _sourceWithBlackCross = new PortbaleBitmap(10, 10, new bool[100]);
            for (var i = 0; i < 10; i++)
            {
                _sourceWithBlackCross[i, i] = true;
                _sourceWithBlackCross[9 - i, i] = true;
            }
        }

        private IPortableBitmapToConverter<BitmapSource> _converter;

        private IPortbaleBitmap _sourceWithBlackCross;


        [Test]
        public void TestWithBlackCrossImage()
        {
            var bitmapSource = _converter.ConvertFrom(_sourceWithBlackCross);
            //this is ugly, but we cant directyly access pixels in a bitmap source.
            var bitmap = bitmapSource.ConvertToBitmap();
            Assert.AreEqual(10, bitmapSource.Width, "Width");
            Assert.AreEqual(10, bitmapSource.Height, "Height");

            for (var y = 0; y < 10; y++)
            {
                for (var x = 0; x < 10; x++)
                {
                    var expectedColor = (x == y || 9 - x == y) ? Color.Black : Color.White;
                    var actualColor = bitmap.GetPixel(x, y);

                    Assert.AreEqual(expectedColor.A, actualColor.A, "Alpha {0}/{1}".FormatWith(x, y));
                    Assert.AreEqual(expectedColor.R, actualColor.R, "Red {0}/{1}".FormatWith(x, y));
                    Assert.AreEqual(expectedColor.G, actualColor.G, "Green {0}/{1}".FormatWith(x, y));
                    Assert.AreEqual(expectedColor.B, actualColor.B, "Blue {0}/{1}".FormatWith(x, y));
                }
            }
        }
    }
}