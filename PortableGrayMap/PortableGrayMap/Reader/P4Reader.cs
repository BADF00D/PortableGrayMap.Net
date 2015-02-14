namespace PortableGrayMap.Reader
{
    using System.Collections.Generic;
    using System.IO;

    internal class P4Reader : BasicReader<IPortbaleBitmap, bool>, IPortableBitmapReader
    {
        protected override string ExpectedMagicNumber
        {
            get { return "P4"; }
        }

        protected override IPortbaleBitmap ContinueReadImage(BinaryReader reader, int width, int height)
        {
            var pixels = new bool[width*height];
            var index = 0;

            SkipWhiteSpaceCharacters(reader);

            for (var i = 0; i < pixels.Length/8; i++)
            {
                var @byte = reader.ReadByte();
                EncodeByteAndStoreDate(pixels, @byte, index);
                index += 8;
            }

            return new PortbaleBitmap(width, height, pixels);
        }

        private static void EncodeByteAndStoreDate(IList<bool> pixels, byte b, int index)
        {
            pixels[index + 0] = (b & 128) > 0;
            pixels[index + 1] = (b & 64) > 0;
            pixels[index + 2] = (b & 32) > 0;
            pixels[index + 3] = (b & 16) > 0;
            pixels[index + 4] = (b & 8) > 0;
            pixels[index + 5] = (b & 4) > 0;
            pixels[index + 6] = (b & 2) > 0;
            pixels[index + 7] = (b & 1) > 0;
        }
    }
}