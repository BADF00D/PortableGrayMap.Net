namespace PortableGrayMapTest.Writer
{
    using System.Drawing.Imaging;
    using System.IO;
    using NUnit.Framework;
    using PortableGrayMap;
    using PortableGrayMap.Writer;

    [TestFixture]
    public class P3WriterTest
    {
        [SetUp]
        public void Setup()
        {
            _writer = new P3Writer();
            _imageWithBytePixels = new PortablePixmap(2, 2,
                new[]
                {
                    new RgbPixel(0x000000), new RgbPixel(0xFF0000), 
                    new RgbPixel(0x00FF00), new RgbPixel(0x0000FF)
                });
        }

        private IPortableMapWriter<IPortablePixmap> _writer;
        private IPortablePixmap _imageWithBytePixels;

        [Test]
        public void TestWithByteImageOnStream()
        {
            using (var memoryStream = new MemoryStream())
            {
                _writer.WriteToStream(memoryStream, _imageWithBytePixels);
                var data = memoryStream.ToArray();

                Assert.AreEqual(37, data.Length);
                Assert.AreEqual('P', data[0], "0 P");
                Assert.AreEqual('3', data[1], "1 2");
                Assert.AreEqual('\r', data[2], "2 NewLine");
                Assert.AreEqual('2', data[3], "3 2");
                Assert.AreEqual(' ', data[4], "4 Space");
                Assert.AreEqual('2', data[5], "5 2");
                Assert.AreEqual('\r', data[6], "6 NewLine");
                //Pixel [0,0] 0x000000
                Assert.AreEqual('0', data[7], "7 Pixel[0,0] red");
                Assert.AreEqual(' ', data[8], "8 Pixel[0,0] ");
                Assert.AreEqual('0', data[9], "9 Pixel[0,0] green");
                Assert.AreEqual(' ', data[10], "10 Pixel[0,0]");
                Assert.AreEqual('0', data[11], "11 Pixel[0,0] blue");
                Assert.AreEqual(' ', data[12], "12 Pixel[0,0]");
                //Pixel [0,1] 0xFF0000
                Assert.AreEqual('2', data[13], "13 Pixel[1,0].red");
                Assert.AreEqual('5', data[14], "14 Pixel[1,0].red");
                Assert.AreEqual('5', data[15], "15 Pixel[1,0].red");
                Assert.AreEqual(' ', data[16], "16 Pixel[0,0]");
                Assert.AreEqual('0', data[17], "17 Pixel[1,0].green");
                Assert.AreEqual(' ', data[18], "18 Pixel[1,0]");
                Assert.AreEqual('0', data[19], "19 Pixel[1,0].blue");
                Assert.AreEqual(' ', data[20], "20 Pixel[1,0]");
                //Pixel [1,0] 0x00FF00
                Assert.AreEqual('0', data[21], "21 Pixel[0,1].red");
                Assert.AreEqual(' ', data[22], "22 Pixel[0,1]");
                Assert.AreEqual('2', data[23], "23 Pixel[0,1].green");
                Assert.AreEqual('5', data[24], "24 Pixel[0,1].green");
                Assert.AreEqual('5', data[25], "25 Pixel[0,1].green");
                Assert.AreEqual(' ', data[26], "26 Pixel[0,1]");
                Assert.AreEqual('0', data[27], "27 Pixel[0,1].blue");
                Assert.AreEqual(' ', data[28], "28 Pixel[0,1]");
                //Pixel [1,1] 0x0000FF
                Assert.AreEqual('0', data[29], "29 Pixel[1,1].red");
                Assert.AreEqual(' ', data[30], "30 Pixel[1,1]");
                Assert.AreEqual('0', data[31], "31 Pixel[1,1].green");
                Assert.AreEqual(' ', data[32], "32 Pixel[1,1]");
                Assert.AreEqual('2', data[33], "33 Pixel[1,1].blue");
                Assert.AreEqual('5', data[34], "34 Pixel[1,1].blue");
                Assert.AreEqual('5', data[35], "35 Pixel[1,1].blue");
                Assert.AreEqual(' ', data[36], "136 Pixel[1,1]");
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