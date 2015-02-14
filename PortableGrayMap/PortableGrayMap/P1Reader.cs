namespace PortableGrayMap
{
    using System;
    using System.IO;
    using System.Text;

    internal class P1Reader : IPortbaleMapReader<IPortbaleBitmap, bool>
    {
        private const string MagicNumberForP1 = "P1";


        public IPortbaleBitmap ReadFromStream(Stream stream)
        {
            if(stream == null) throw new ArgumentNullException("stream");
            if(!stream.CanRead) throw new ArgumentException("Cannot read from stream.");

            var reader = new StreamReader(stream, Encoding.ASCII);
            var magicNumber = ReadMagicNumber(reader);
            if (magicNumber != MagicNumberForP1) throw new ArgumentException(string.Format("MagicNumberForP1 {0} differs from expected {1}", magicNumber, MagicNumberForP1));

            return null;
        }

        private static string ReadMagicNumber(TextReader reader)
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