namespace PortableGrayMapTest.Converter
{
    using System.Drawing;
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
    }
}