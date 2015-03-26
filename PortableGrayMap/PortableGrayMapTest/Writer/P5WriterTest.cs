namespace PortableGrayMapTest.Writer
{
    using System.IO;
    using NUnit.Framework;
    using PortableGrayMap;
    using PortableGrayMap.Writer;

    [TestFixture]
    internal class P5WriterTest
    {
        private IPortableGraymapWriter _writer;

        private IPortableGraymap _imageWithBytes;

        private IPortableGraymap _imageWithUShorts;

        [SetUp]
        public void Setup()
        {
            _writer = new P5Writer();
            _imageWithBytes = new PortableGraymap(2,2, new ushort[]{10,20,30,40}, 255);
            _imageWithUShorts = new PortableGraymap(2,2,new ushort[]{50,60,70,800}, 800);
        }

        [Test]
        public void TestImageWithBytes()
        {
            using (var memoryStream = new MemoryStream())
            {
                _writer.WriteToStream(memoryStream, _imageWithBytes);

                var data = memoryStream.ToArray();

                Assert.AreEqual(15, data.Length);
                Assert.AreEqual('P', data[0], "0 P");
                Assert.AreEqual('5', data[1], "1 4");
                Assert.AreEqual('\r', data[2], "2 NewLine");
                Assert.AreEqual('2', data[3], "3 2");
                Assert.AreEqual(' ', data[4], "4 Space");
                Assert.AreEqual('2', data[5], "5 2");
                Assert.AreEqual('\r', data[6], "6 NewLine");
                Assert.AreEqual('2', data[7], "2 MaxValue");
                Assert.AreEqual('5', data[8], "5 MaxValue");
                Assert.AreEqual('5', data[9], "5 MaxValue");
                Assert.AreEqual('\r', data[10], "6 NewLine");
                Assert.AreEqual(10, data[11], "Pixel[0,0]");
                Assert.AreEqual(20, data[12], "Pixel[0,1]");
                Assert.AreEqual(30, data[13], "Pixel[1,0]");
                Assert.AreEqual(40, data[14], "Pixel[1,1]");
            }
        }

        [Test]
        public void TestImageWithUShorts()
        {
            using (var memoryStream = new MemoryStream())
            {
                _writer.WriteToStream(memoryStream, _imageWithUShorts);

                var data = memoryStream.ToArray();

                Assert.AreEqual(19, data.Length);
                Assert.AreEqual('P', data[0], "0 P");
                Assert.AreEqual('5', data[1], "1 4");
                Assert.AreEqual('\r', data[2], "2 NewLine");
                Assert.AreEqual('2', data[3], "3 2");
                Assert.AreEqual(' ', data[4], "4 Space");
                Assert.AreEqual('2', data[5], "5 2");
                Assert.AreEqual('\r', data[6], "6 NewLine");
                Assert.AreEqual('8', data[7], "2 MaxValue");
                Assert.AreEqual('0', data[8], "5 MaxValue");
                Assert.AreEqual('0', data[9], "5 MaxValue");
                Assert.AreEqual('\r', data[10], "6 NewLine");
                Assert.AreEqual(0, data[11], "Pixel[0,0]");
                Assert.AreEqual(50, data[12], "Pixel[0,0]");
                Assert.AreEqual(0, data[13], "Pixel[0,1]");
                Assert.AreEqual(60, data[14], "Pixel[0,1]");
                Assert.AreEqual(0, data[15], "Pixel[1,0]");
                Assert.AreEqual(70, data[16], "Pixel[1,0]");
                Assert.AreEqual(0x3, data[17], "Pixel[1,1]");
                Assert.AreEqual(0x20, data[18], "Pixel[1,1]");
            }
        }
    }
}
