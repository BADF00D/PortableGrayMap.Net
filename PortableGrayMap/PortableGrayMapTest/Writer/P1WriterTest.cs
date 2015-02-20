namespace PortableGrayMapTest.Writer
{
    using System.IO;
    using NUnit.Framework;
    using PortableGrayMap;
    using PortableGrayMap.Writer;

    [TestFixture]
    public class P1WriterTest
    {
        [SetUp]
        public void Setup()
        {
            _writer = new P1Writer();
            _smallImage = new PortbaleBitmap(2, 2, new[] {true, true, false, false});
        }

        private IPortableMapWriter<IPortbaleBitmap> _writer;
        private IPortbaleBitmap _smallImage;

        [Test]
        public void TestWithSmallImageOnFile()
        {
            var tmpFileName = Path.GetTempPath() + Path.GetRandomFileName() + ".pgm";
            _writer.WriteToFile(tmpFileName, _smallImage);

            File.Delete(tmpFileName);
        }

        [Test]
        public void TestWithSmallImageOnStream()
        {
            using (var memoryStream = new MemoryStream())
            {
                _writer.WriteToStream(memoryStream, _smallImage);
                var data = memoryStream.ToArray();

                Assert.AreEqual(15, data.Length);
                Assert.AreEqual('P', data[0], "0 P");
                Assert.AreEqual('1', data[1], "1 1");
                Assert.AreEqual('\r', data[2], "2 NewLine");
                Assert.AreEqual('2', data[3], "3 2");
                Assert.AreEqual(' ', data[4], "4 Space");
                Assert.AreEqual('2', data[5], "5 2");
                Assert.AreEqual('\r', data[6], "5 Space");
                Assert.AreEqual('1', data[7], "5 2");
                Assert.AreEqual(' ', data[8], "5 2");
                Assert.AreEqual('1', data[9], "5 2");
                Assert.AreEqual(' ', data[10], "5 2");
                Assert.AreEqual('0', data[11], "5 2");
                Assert.AreEqual(' ', data[12], "5 2");
                Assert.AreEqual('0', data[13], "5 2");
                Assert.AreEqual(' ', data[14], "5 2");
            }
        }
    }
}