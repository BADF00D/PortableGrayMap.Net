namespace PortableGrayMap.Reader
{
    using System.IO;

    internal class P5Reader : BasicReader<IPortableGraymap, ushort>, IPortableGraymapReader
    {
        protected override string ExpectedMagicNumber
        {
            get { return "P5"; }
        }

        protected override IPortableGraymap ContinueReadImage(BinaryReader reader, int width, int height)
        {
            var maxValue = ReadNextInt(reader);


            var pixels = maxValue < 256
                ? ReadSingleBytePixel(width, height, reader)
                : ReadTwoBytePixel(width, height, reader);

            return new PortableGraymap(width, height, pixels, (ushort) maxValue);
        }

        private static ushort[] ReadTwoBytePixel(int width, int height, BinaryReader reader)
        {
            var pixel = new ushort[width*height];
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    pixel[y*width + x] = reader.ReadByte();
                }
            }

            return pixel;
        }

        private static ushort[] ReadSingleBytePixel(int width, int height, BinaryReader reader)
        {
            var pixel = new ushort[width*height];
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    pixel[y*width + x] = reader.ReadUInt16();
                }
            }

            return pixel;
        }
    }
}