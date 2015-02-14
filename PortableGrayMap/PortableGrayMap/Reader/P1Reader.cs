namespace PortableGrayMap.Reader
{
    using System.IO;

    internal class P1Reader : BasicReader<IPortbaleBitmap, bool>
    {
        protected override string ExpectedMagicNumber
        {
            get { return "P1"; }
        }

        protected override IPortbaleBitmap ContinueReadImage(BinaryReader reader, int width, int height)
        {
            var pixels = ReadPixels(reader, width, height);

            return new PortbaleBitmap(width, height, pixels);
        }

        private static bool[] ReadPixels(BinaryReader reader, int width, int height)
        {
            var pixels = new bool[width*height];
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    pixels[y*width + x] = ReadNextInt(reader) == 1;
                }
            }

            return pixels;
        }
    }
}