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
            var converter = ConverterFactory.ToBitmapConverter;

            Assert.IsNotNull(converter);
        }

        [Test]
        public void TestWithBitmapSource()
        {
            var converter = ConverterFactory.ToBitmapSourceConverter;

            Assert.IsNotNull(converter);
        }
    }
}