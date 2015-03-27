namespace PortableGrayMapTest.Converter
{
    using NUnit.Framework;
    using PortableGrayMap.Converter;

    [TestFixture]
    public class ConverterFactoryTest
    {
        [Test]
        public void TestPortableBitmapToBitmapConverter()
        {
            var converter = ConverterFactory.PortableBitmapToBitmapConverter;

            Assert.IsNotNull(converter);
        }

        [Test]
        public void TestPortableBitmapToBitmapSourceConverter()
        {
            var converter = ConverterFactory.PortableBitmapToBitmapSourceConverter;

            Assert.IsNotNull(converter);
        }

        [Test]
        public void TestPortableGraymapToBitmapConverter()
        {
            var converter = ConverterFactory.PortableGraymapToBitmapConverter;

            Assert.IsNotNull(converter);
        }

        [Test]
        public void TestPortableGraymapToBitmapSourceConverter()
        {
            var converter = ConverterFactory.PortableGraymapToBitmapSourceConverter;

            Assert.IsNotNull(converter);
        }

        [Test]
        public void TestPortablePixmapToBitmapConverter()
        {
            var converter = ConverterFactory.PortablePixmapToBitmapConverter;

            Assert.IsNotNull(converter);
        }

        [Test]
        public void TestPortablePixmapToBitmapSourceConverter()
        {
            var converter = ConverterFactory.PortablePixmapToBitmapSourceConverter;

            Assert.IsNotNull(converter);
        }
    }
}