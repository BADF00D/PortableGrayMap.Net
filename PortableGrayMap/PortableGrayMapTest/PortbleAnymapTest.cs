namespace PortableGrayMapTest
{
    using NUnit.Framework;
    using PortableGrayMap;

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