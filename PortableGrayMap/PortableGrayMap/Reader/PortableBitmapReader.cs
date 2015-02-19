namespace PortableGrayMap.Reader
{
    using System;
    using System.Globalization;
    using System.IO;
    using Tanpohp.Extensions;

    public class PortableBitmapReader : IPortableBitmapReader
    {
        /// <summary>
        /// Reads a image from stream.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown if stream is null.</exception>
        /// <exception cref="ArgumentException">Thrown if stream can not be seeked. This is used to determine magic 
        /// string. If you know the magic string, use excact reader froom Reader.ReaderFactory.</exception>
        public IPortbaleBitmap ReadFromStream(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException("stream");
            if (stream.CanSeek) throw new ArgumentException("Given stream can not be seeked.");

            var magicString = new BinaryReader(stream).ReadChars(2)
                .ItemsToString(@char => @char.ToString(CultureInfo.InvariantCulture), string.Empty);
            stream.Seek(-2, SeekOrigin.Current);

            IPortableBitmapReader reader;
            switch (magicString)
            {
                case "P1":
                    reader = ReaderFactory.AsciiPortableBitmapReader;
                    break;
                case "P4":
                    reader = ReaderFactory.BinaryPortableBitmapReader;
                    break;
                default:
                    throw new ArgumentException("Unexpected magic string '{0}'.Expected 'P1' or 'P4'.");
            }

            return reader.ReadFromStream(stream);
        }

        public IPortbaleBitmap ReadFromFile(string filePath)
        {
            if (!File.Exists(filePath)) throw new ArgumentException("Given filePath does snot exists.");

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                return ReadFromStream(stream);
            }
        }
    }
}