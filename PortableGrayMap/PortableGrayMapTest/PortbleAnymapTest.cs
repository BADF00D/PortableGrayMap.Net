namespace PortableGrayMapTest
{
    using System.Collections.Generic;
    using System.IO;
    using NUnit.Framework;
    using PortableGrayMap;
    using PortableGrayMap.Reader;

    [TestFixture]
    public class PortbleAnymapTest
    {
        private class DummyMap : PortbleAnymap<bool>
        {
            public DummyMap(int width, int height, bool[] pixels) : base(width, height, pixels)
            {
            }
        }

        [Test]
        public void IndexerGet()
        {
            var image = new DummyMap(3, 3, new[] {true, false, true, false, true, false, true, false, true});

            Assert.AreEqual(true, image[0, 0], "Pixel 0/0");
            Assert.AreEqual(true, image[1, 1], "Pixel 1/1");
            Assert.AreEqual(true, image[2, 2], "Pixel 2/2");
            Assert.AreEqual(false, image[1, 0], "Pixel 1/0");
        }

        public void T()
        {
            var p1Reader = ReaderFactory.AsciiPortableBitmapReader;
            IList<IPortbaleBitmap> images = new List<IPortbaleBitmap>();
            using(var fileStream = new FileStream("pathToFile.pbm", FileMode.Open)){
                if(fileStream.Position < fileStream.Length){
                    images.Add(p1Reader.ReadFromStream(fileStream));
                }
            }
        }
        [Test]
        public void IndexerSet()
        {
            var image = new DummyMap(3, 3, new[] {true, false, true, false, true, false, true, false, true});
            image[0, 0] = false;
            image[2, 0] = false;
            image[1, 1] = false;
            image[0, 2] = false;
            image[2, 2] = false;

            for (var y = 0; y < 3; y++)
            {
                for (var x = 0; x < 3; x++)
                {
                    Assert.IsFalse(image.Pixels[y*3 + x]);
                }
            }
        }
    }
}