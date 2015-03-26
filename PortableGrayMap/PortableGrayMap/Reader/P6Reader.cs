namespace PortableGrayMap.Reader
{
    using System.IO;

    internal class P6Reader : BasicReader<IPortablePixmap>, IPortablePixmapReader
    {
        protected override string ExpectedMagicNumber
        {
            get { return "P6"; }
        }

        protected override IPortablePixmap ContinueReadImage(BinaryReader reader, int width, int height)
        {
            var maxValue = (ushort) ReadNextInt(reader);
            var pixels = new RgbPixel[width*height];
            SkipWhiteSpaceCharacters(reader);
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var red = reader.ReadByte();
                    var green = reader.ReadByte();
                    var blue = reader.ReadByte();

                    pixels[y*width + x] = new RgbPixel(red, green, blue);
                }
            }

            return new PortablePixmap(width, height, pixels, maxValue);
        }
    }
}