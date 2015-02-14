namespace PortableGrayMap.Reader
{
    using System;
    using System.IO;
    using System.Text;
    using Tanpohp.Extensions;

    internal class P1Reader : IPortbaleMapReader<IPortbaleBitmap, bool>
    {
        private const string MagicNumberForP1 = "P1";


        public IPortbaleBitmap ReadFromStream(Stream stream)
        {
            if(stream == null) throw new ArgumentNullException("stream");
            if(!stream.CanRead) throw new ArgumentException("Cannot read from stream.");

            var reader = new BinaryReader(stream, Encoding.ASCII);
            var magicNumber = ReadMagicNumber(reader);
            if (magicNumber != MagicNumberForP1) throw new ArgumentException("MagicNumberForP1 {0} differs from expected {1}".FormatWith(magicNumber, MagicNumberForP1));
            var width = ReadNextInt(reader);
            var height = ReadNextInt(reader);
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

        private static int ReadNextInt(BinaryReader reader)
        {
            SkipWhiteSpaceCharacters(reader);

            var rawString = new StringBuilder();
            while (char.IsDigit((char) reader.PeekChar()))
            {
                rawString.Append(reader.ReadChar());
            }

            return Int32.Parse(rawString.ToString());
        }

        private static void SkipWhiteSpaceCharacters(BinaryReader reader)
        {
            var currentChar = (char)reader.PeekChar();
            while (char.IsWhiteSpace(currentChar))
            {
                reader.ReadChar();
                currentChar = (char)reader.PeekChar();
                while (currentChar == '#')
                {
                    SkipCommentLine(reader);
                    currentChar = (char)reader.PeekChar();
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

        public IPortbaleBitmap ReadFromFile(string path)
        {
            
            if(!File.Exists(path)) throw new ArgumentException("File does not exists.");
            using (var stream = new FileStream(path, FileMode.Open))
            {
                return ReadFromStream(stream);
            }
        }
    }
}