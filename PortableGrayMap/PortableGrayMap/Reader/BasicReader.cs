namespace PortableGrayMap.Reader
{
    using System;
    using System.IO;
    using System.Text;
    using Tanpohp.Extensions;

    internal abstract class BasicReader<TMap, TPixel> : IPortbaleMapReader<TMap, TPixel>
        where TMap : IPortbleAnymap<TPixel>
    {
        protected abstract string ExpectedMagicNumber { get; }

        public virtual TMap ReadFromStream(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException("stream");
            if (!stream.CanRead) throw new ArgumentException("Cannot read from stream.");

            var reader = new BinaryReader(stream, Encoding.ASCII);
            var magicNumber = ReadMagicNumber(reader);
            if (magicNumber != ExpectedMagicNumber)
                throw new ArgumentException("MagicNumberFor '{0}' differs from expected '{1}'".FormatWith(magicNumber,
                    ExpectedMagicNumber));
            var width = ReadNextInt(reader);
            var height = ReadNextInt(reader);

            return ContinueReadImage(reader, width, height);
        }


        public TMap ReadFromFile(string path)
        {
            if (!File.Exists(path)) throw new ArgumentException("File does not extists.");
            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                return ReadFromStream(fileStream);
            }
        }

        /// <summary>
        /// Continues to read partial read image. Readers position is directly after HEIGHT in file.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        protected abstract TMap ContinueReadImage(BinaryReader reader, int width, int height);

        /// <summary>
        /// Reads from reader as long is current caracter is a digit and returns the whole number.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected static int ReadNextInt(BinaryReader reader)
        {
            SkipWhiteSpaceCharacters(reader);

            var rawString = new StringBuilder();
            while (char.IsDigit((char) reader.PeekChar()))
            {
                rawString.Append(reader.ReadChar());
            }

            return Int32.Parse(rawString.ToString());
        }

        /// <summary>
        /// Skips seeks reader to next non whitespace. If it find a comment, this is also skipped.
        /// </summary>
        /// <param name="reader"></param>
        protected static void SkipWhiteSpaceCharacters(BinaryReader reader)
        {
            var currentChar = (char) reader.PeekChar();
            while (char.IsWhiteSpace(currentChar))
            {
                reader.ReadChar();
                currentChar = (char) reader.PeekChar();
                while (currentChar == '#')
                {
                    SkipCommentLine(reader);
                    currentChar = (char) reader.PeekChar();
                }
            }
        }

        private static void SkipCommentLine(BinaryReader reader)
        {
            var currentChar = (char) reader.PeekChar();
            while (currentChar != '\r' && currentChar != '\n')
            {
                currentChar = reader.ReadChar();
            }
        }

        private static string ReadMagicNumber(BinaryReader reader)
        {
            var buffer = new char[2];
            reader.Read(buffer, 0, 2);

            return buffer[0] + "" + buffer[1];
        }
    }
}