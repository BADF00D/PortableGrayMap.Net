namespace PortableGrayMap.Reader
{
    using System.IO;

    internal class P2Reader : BasicReader<IPortableGraymap>, IPortableGraymapReader
    {
        protected override string ExpectedMagicNumber
        {
            get { return "P2"; }
        }

        protected override IPortableGraymap ContinueReadImage(BinaryReader reader, int width, int height)
        {
            var maxValue = (ushort)ReadNextInt(reader);

            var pixels = new ushort[width * height];
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    pixels[y * width + x] = (ushort)ReadNextInt(reader);
                }
            }

            return new PortableGraymap(width, height, pixels, maxValue);
        }
    }
}