namespace PortableGrayMapTest
{
    using System;
    using System.IO;
    using NUnit.Framework;
    using PortableGrayMap;

    [TestFixture]
    public class P1ReaderTest
    {
        private const string PathToSampleFolder = @"../../../Sources/Samples/P1/";

        [SetUp]
        public void Setup()
        {
            _reader = new P1Reader();
        }

        private IPortbaleMapReader<IPortbaleBitmap, bool> _reader;

        [Test]
        public void CheckSizeOfSampleCircle()
        {
            var image = _reader.ReadFromFile(Path.Combine(PathToSampleFolder, "circle.ascii.pbm"));

            Assert.AreEqual(200, image.Width);
            Assert.AreEqual(200, image.Height);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckmagicNumber()
        {
            _reader.ReadFromFile(Path.Combine(PathToSampleFolder, "../P4/", "feed.pbm"));
        }
    }
}