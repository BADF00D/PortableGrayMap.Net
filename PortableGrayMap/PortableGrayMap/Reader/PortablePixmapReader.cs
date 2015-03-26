namespace PortableGrayMap.Reader
{
    using System;
    using System.Globalization;
    using System.IO;
    using Tanpohp.Extensions;

    internal class PortablePixmapReader : IPortablePixmapReader
    {
        public IPortablePixmap ReadFromStream(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException("stream");
            if (stream.CanSeek) throw new ArgumentException("Given stream can not be seeked.");

            var magicString = new BinaryReader(stream).ReadChars(2)
                .ItemsToString(@char => @char.ToString(CultureInfo.InvariantCulture), string.Empty);
            stream.Seek(-2, SeekOrigin.Current);

            IPortablePixmapReader reader;
            switch (magicString)
            {
                case "P3":
                    reader = ReaderFactory.AsciiPortablePixmapReader;
                    break;
                case "P6":
                    reader = ReaderFactory.BinaryPortablePixmapReader;
                    break;
                default:
                    throw new ArgumentException("Unexpected magic string '{0}'.Expected 'P3' or 'P6'.");
            }

            return reader.ReadFromStream(stream);
        }

        public IPortablePixmap ReadFromFile(string filePath)
        {
            if (!File.Exists(filePath)) throw new ArgumentException("Given filePath does snot exists.");

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                return ReadFromStream(stream);
            }
        }
    }
}