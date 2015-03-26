namespace PortableGrayMap.Reader
{
    using System.IO;

    internal class P3Reader : BasicReader<IPortablePixmap>, IPortablePixmapReader
    {
        protected override string ExpectedMagicNumber
        {
            get { return "P3"; }
        }

        protected override IPortablePixmap ContinueReadImage(BinaryReader reader, int width, int height)
        {
            var maxValue = (ushort)ReadNextInt(reader);
            var pixels = new RgbPixel[width*height];
            
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var red = (byte)ReadNextInt(reader);
                    var green = (byte)ReadNextInt(reader);
                    var blue = (byte)ReadNextInt(reader);

                    pixels[y*width + x] = new RgbPixel(red, green, blue);
                }
            }

            return new PortablePixmap(width, height, pixels, maxValue);
        }
    }
}