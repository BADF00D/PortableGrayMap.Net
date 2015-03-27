namespace PortableGrayMapTest.Converter
{
    using System.Drawing;
    using NUnit.Framework;
    using PortableGrayMap;
    using PortableGrayMap.Converter;
    using Tanpohp.Extensions;

    [TestFixture]
    public class PortableBitmapToBitmapConverterTest
    {
        [SetUp]
        public void Setup()
        {
            _converter = new PortableBitmapToBitmapConverter();

            _sourceWithBlackCross = new PortbaleBitmap(10, 10, new bool[100]);
            _sourceWithDiagonalLine = new PortbaleBitmap(10, 10, new bool[100]);
            for (var i = 0; i < 10; i++)
            {
                _sourceWithBlackCross[i, i] = true;
                _sourceWithBlackCross[9 - i, i] = true;
                _sourceWithDiagonalLine[i, i] = true;
            }

            
        }

        private IConverter<IPortbaleBitmap, Bitmap> _converter;

        private IPortbaleBitmap _sourceWithBlackCross, _sourceWithDiagonalLine;

        [Test]
        public void TestWithBlackCrossImage()
        {
            using (var bitmap = _converter.Convert(_sourceWithBlackCross))
            {
                Assert.AreEqual(10, bitmap.Width);
                Assert.AreEqual(10, bitmap.Height);

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

        [Test]
        public void TestWithDiagonalLine()
        {
            using (var bitmap = _converter.Convert(_sourceWithDiagonalLine))
            {
                Assert.AreEqual(10, bitmap.Width);
                Assert.AreEqual(10, bitmap.Height);

                for (var y = 0; y < 10; y++)
                {
                    for (var x = 0; x < 10; x++)
                    {
                        var expectedColor = (x == y) ? Color.Black : Color.White;
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
}