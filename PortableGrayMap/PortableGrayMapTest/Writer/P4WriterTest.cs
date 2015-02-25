using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortableGrayMapTest.Writer
{
    using System.IO;
    using NUnit.Framework;
    using PortableGrayMap;
    using PortableGrayMap.Writer;

    [TestFixture]
    public class P4WriterTest
    {
        [SetUp]
        public void Setup()
        {
            _writer = new P4Writer();
            _smallImage = new PortbaleBitmap(2, 2,
                new[]
                {
                    true, false, true, false
                });
            _biggerImage = new PortbaleBitmap(5, 2,
                new[] {true, false, true, false, true, 
                    true, false, true, false, true});
        }

        private IPortableMapWriter<IPortbaleBitmap> _writer;
        private IPortbaleBitmap _smallImage;
        private IPortbaleBitmap _biggerImage;

        [Test]
        public void TestWithSmallImage()
        {
            using (var memoryStream = new MemoryStream())
            {
                _writer.WriteToStream(memoryStream, _smallImage);
                var data = memoryStream.ToArray();

                Assert.AreEqual(8, data.Length);
                Assert.AreEqual('P', data[0], "0 P");
                Assert.AreEqual('4', data[1], "1 4");
                Assert.AreEqual('\r', data[2], "2 NewLine");
                Assert.AreEqual('2', data[3], "3 2");
                Assert.AreEqual(' ', data[4], "4 Space");
                Assert.AreEqual('2', data[5], "5 2");
                Assert.AreEqual('\r', data[6], "6 NewLine");
                Assert.AreEqual(0xA0, data[7], "Pixel 0-7");//1010 1100
            }
        }
        [Test]
        public void TestWithBiggerImage()
        {
            using (var memoryStream = new MemoryStream())
            {
                _writer.WriteToStream(memoryStream, _biggerImage);
                var data = memoryStream.ToArray();

                Assert.AreEqual(9, data.Length, "Data Size");
                Assert.AreEqual('P', data[0], "0 P");
                Assert.AreEqual('4', data[1], "1 4");
                Assert.AreEqual('\r', data[2], "2 NewLine");
                Assert.AreEqual('5', data[3], "3 5");
                Assert.AreEqual(' ', data[4], "4 Space");
                Assert.AreEqual('2', data[5], "5 2");
                Assert.AreEqual('\r', data[6], "6 NewLine");
                Assert.AreEqual(0xAD, data[7], "Pixel 0-7");//1010 0000
                Assert.AreEqual(0x40, data[8], "Pixel 8-9");//1010 0000
            }
        }
    }
}
