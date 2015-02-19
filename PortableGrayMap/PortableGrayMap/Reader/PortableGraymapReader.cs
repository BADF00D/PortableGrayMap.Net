namespace PortableGrayMap.Reader
{
    using System;
    using System.Globalization;
    using System.IO;
    using Tanpohp.Extensions;

    public class PortableGraymapReader : IPortableGraymapReader
    {
        /// <summary>
        /// Reads a image from stream.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown if stream is null.</exception>
        /// <exception cref="ArgumentException">Thrown if stream can not be seeked. This is used to determine magic 
        /// string. If you know the magic string, use excact reader froom Reader.Factory.</exception>
        public IPortableGraymap ReadFromStream(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException("stream");
            if (stream.CanSeek) throw new ArgumentException("Given stream can not be seeked.");

            var magicString = new BinaryReader(stream).ReadChars(2)
                .ItemsToString(@char => @char.ToString(CultureInfo.InvariantCulture), string.Empty);
            stream.Seek(-2, SeekOrigin.Current);

            IPortableGraymapReader reader;
            switch (magicString)
            {
                case "P2":
                    reader = Factory.GetReaderForAsciiPortableGraymap();
                    break;
                case "P5":
                    reader = Factory.GetReaderForBinaryPortableGraymap();
                    break;
                default:
                    throw new ArgumentException("Unexpected magic string '{0}'.Expected 'P1' or 'P4'.");
            }

            return reader.ReadFromStream(stream);
        }

        public IPortableGraymap ReadFromFile(string filePath)
        {
            if (!File.Exists(filePath)) throw new ArgumentException("Given filePath does not exists.");

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                return ReadFromStream(stream);
            }
        }
    }
}