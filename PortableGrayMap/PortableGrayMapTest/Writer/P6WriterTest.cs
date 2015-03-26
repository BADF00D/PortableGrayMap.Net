namespace PortableGrayMapTest.Writer
{
    using System.IO;
    using NUnit.Framework;
    using PortableGrayMap;
    using PortableGrayMap.Writer;

    internal class P6WriterTest
    {
        private IPortablePixmap _imageWithBytePixels;
        private IPortableMapWriter<IPortablePixmap> _writer;

        [SetUp]
        public void Setup()
        {
            _writer = new P6Writer();
            _imageWithBytePixels = new PortablePixmap(2, 2,
                new[]
                {
                    new RgbPixel(0x000000), new RgbPixel(0xFF0000),
                    new RgbPixel(0x00FF00), new RgbPixel(0x0000FF)
                }, 0xFF); //todo test max Value
        }

        [Test]
        public void TestSampleImage()
        {
            using (var memoryStream = new MemoryStream())
            {
                _writer.WriteToStream(memoryStream, _imageWithBytePixels);
                var data = memoryStream.ToArray();
                var i = -1;
                Assert.AreEqual(23, data.Length);
                Assert.AreEqual('P', data[++i], "0 P");
                Assert.AreEqual('6', data[++i], "1 6");
                Assert.AreEqual('\r', data[++i], "2 NewLine");
                Assert.AreEqual('2', data[++i], "3 2");
                Assert.AreEqual(' ', data[++i], "4 Space");
                Assert.AreEqual('2', data[++i], "5 2");
                Assert.AreEqual('\r', data[++i], "6 NewLine");
                Assert.AreEqual('2', data[++i], "7 2");
                Assert.AreEqual('5', data[++i], "8 5");
                Assert.AreEqual('5', data[++i], "9 5");
                Assert.AreEqual('\r', data[++i], "10 NewLine");
                //Pixel [0,0] 0x000000
                Assert.AreEqual(0, data[++i], "11 Pixel[0,0] red");
                Assert.AreEqual(0, data[++i], "13 Pixel[0,0] green");
                Assert.AreEqual(0, data[++i], "15 Pixel[0,0] blue");
                //Pixel [0,1] 0xFF0000
                Assert.AreEqual(255, data[++i], "17 Pixel[1,0].red");
                Assert.AreEqual(0, data[++i], "21 Pixel[1,0].green");
                Assert.AreEqual(0, data[++i], "23 Pixel[1,0].blue");
                //Pixel [1,0] 0x00FF00
                Assert.AreEqual(0, data[++i], "25 Pixel[0,1].red");
                Assert.AreEqual(255, data[++i], "26 Pixel[0,1].green");
                Assert.AreEqual(0, data[++i], "30 Pixel[0,1].blue");
                //Pixel [1,1] 0x0000FF
                Assert.AreEqual(0, data[++i], "32 Pixel[1,1].red");
                Assert.AreEqual(0, data[++i], "34 Pixel[1,1].green");
                Assert.AreEqual(255, data[++i], "36 Pixel[1,1].blue");
            }
        }

        [Test]
        public void TestWithSmallImageOnFile()
        {
            var tmpFileName = Path.GetTempPath() + Path.GetRandomFileName() + ".pgm";
            _writer.WriteToFile(tmpFileName, _imageWithBytePixels);

            File.Delete(tmpFileName);
        }
    }
}