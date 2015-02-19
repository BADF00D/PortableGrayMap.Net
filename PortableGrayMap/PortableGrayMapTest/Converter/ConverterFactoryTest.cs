namespace PortableGrayMapTest.Converter
{
    using System;
    using System.Drawing;
    using System.Windows.Media.Imaging;
    using NUnit.Framework;
    using PortableGrayMap.Converter;

    [TestFixture]
    public class ConverterFactoryTest
    {
        [Test]
        public void TestWithBitmap()
        {
            var converter = ConverterFactory.GetConvertFor<Bitmap>();

            Assert.IsNotNull(converter);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWithBitmapSource()
        {
            var converter = ConverterFactory.GetConvertFor<BitmapSource>();
        }
    }
}