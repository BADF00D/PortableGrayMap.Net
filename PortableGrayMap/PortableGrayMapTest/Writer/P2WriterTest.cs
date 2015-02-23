namespace PortableGrayMapTest.Writer
{
    using System.IO;
    using NUnit.Framework;
    using PortableGrayMap;
    using PortableGrayMap.Writer;

    [TestFixture]
    public class P2WriterTest
    {
        [SetUp]
        public void Setup()
        {
            _writer = new P2Writer();
            _imageWithBytePixels = new PortableGraymap(2, 2, new ushort[] {10, 20, 130, 240}, 255);
            _imageWithUshortAsPixels = new PortableGraymap(2, 2, new ushort[] { 10, 20, 130, 2400 }, 2400);
        }

        private IPortableMapWriter<IPortableGraymap> _writer;
        private IPortableGraymap _imageWithBytePixels;
        private IPortableGraymap _imageWithUshortAsPixels;

        [Test]
        public void TestWithSmallImageOnFile()
        {
            var tmpFileName = Path.GetTempPath() + Path.GetRandomFileName() + ".pgm";
            _writer.WriteToFile(tmpFileName, _imageWithBytePixels);

            File.Delete(tmpFileName);
        }

        [Test]
        public void TestWithByteImageOnStream()
        {
            using (var memoryStream = new MemoryStream())
            {
                _writer.WriteToStream(memoryStream, _imageWithBytePixels);
                var data = memoryStream.ToArray();

                Assert.AreEqual(25, data.Length);
                Assert.AreEqual('P', data[0], "0 P");
                Assert.AreEqual('2', data[1], "1 2");
                Assert.AreEqual('\r', data[2], "2 NewLine");
                Assert.AreEqual('2', data[3], "3 2");
                Assert.AreEqual(' ', data[4], "4 Space");
                Assert.AreEqual('2', data[5], "5 2");
                Assert.AreEqual(' ', data[6], "6 Space");
                Assert.AreEqual('2', data[7], "7 MaxValue");
                Assert.AreEqual('5', data[8], "8 MaxValue");
                Assert.AreEqual('5', data[9], "9 MaxValue");
                Assert.AreEqual('\r', data[10], "10 Space");
                Assert.AreEqual('1', data[11], "11 Pixel[0,0]");
                Assert.AreEqual('0', data[12], "12 Pixel[0,0]");
                Assert.AreEqual(' ', data[13], "13 Pixel[0,0]");
                Assert.AreEqual('2', data[14], "14 Pixel[0,0]");
                Assert.AreEqual('0', data[15], "15 Pixel[1,0]");
                Assert.AreEqual(' ', data[16], "16 Pixel[0,0]");
                Assert.AreEqual('1', data[17], "17 Pixel[0,0]");
                Assert.AreEqual('3', data[18], "18 Pixel[0,1]");
                Assert.AreEqual('0', data[19], "19 Pixel[0,1]");
                Assert.AreEqual(' ', data[20], "20 Pixel[0,1]");
                Assert.AreEqual('2', data[21], "21 Pixel[1,1]");
                Assert.AreEqual('4', data[22], "22 Pixel[1,1]");
                Assert.AreEqual('0', data[23], "23 Pixel[1,1]");
                Assert.AreEqual(' ', data[24], "24 Pixel[1,1]");
            }
        }

        [Test]
        public void TestWithUshortImageOnStream()
        {
            using (var memoryStream = new MemoryStream())
            {
                _writer.WriteToStream(memoryStream, _imageWithUshortAsPixels);
                var data = memoryStream.ToArray();

                Assert.AreEqual(27, data.Length);
                Assert.AreEqual('P', data[0], "0 P");
                Assert.AreEqual('2', data[1], "1 2");
                Assert.AreEqual('\r', data[2], "2 NewLine");
                Assert.AreEqual('2', data[3], "3 2");
                Assert.AreEqual(' ', data[4], "4 Space");
                Assert.AreEqual('2', data[5], "5 2");
                Assert.AreEqual(' ', data[6], "6 Space");
                Assert.AreEqual('2', data[7], "7 MaxValue");
                Assert.AreEqual('4', data[8], "8 MaxValue");
                Assert.AreEqual('0', data[9], "9 MaxValue");
                Assert.AreEqual('0', data[10], "9 MaxValue");
                Assert.AreEqual('\r', data[11], "10 Space");
                Assert.AreEqual('1', data[12], "11 Pixel[0,0]");
                Assert.AreEqual('0', data[13], "12 Pixel[0,0]");
                Assert.AreEqual(' ', data[14], "13 Pixel[0,0]");
                Assert.AreEqual('2', data[15], "14 Pixel[0,0]");
                Assert.AreEqual('0', data[16], "15 Pixel[1,0]");
                Assert.AreEqual(' ', data[17], "16 Pixel[0,0]");
                Assert.AreEqual('1', data[18], "17 Pixel[0,0]");
                Assert.AreEqual('3', data[19], "18 Pixel[0,1]");
                Assert.AreEqual('0', data[20], "19 Pixel[0,1]");
                Assert.AreEqual(' ', data[21], "20 Pixel[0,1]");
                Assert.AreEqual('2', data[22], "21 Pixel[1,1]");
                Assert.AreEqual('4', data[23], "22 Pixel[1,1]");
                Assert.AreEqual('0', data[24], "23 Pixel[1,1]");
                Assert.AreEqual('0', data[25], "23 Pixel[1,1]");
                Assert.AreEqual(' ', data[26], "24 Pixel[1,1]");
            }
        }
    }
}