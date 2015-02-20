namespace PortableGrayMap.Writer
{
    using System.Globalization;
    using System.IO;

    internal abstract class BasicWriter<T> : IPortableMapWriter<T>
    {
        protected const char Space = ' ';
        protected const char NewLine = '\r';
        public abstract void WriteToStream(Stream stream, T image);

        public void WriteToFile(string pathToFile, T image)
        {
            using (var fileStream = new FileStream(pathToFile, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fileStream.SetLength(0);
                WriteToStream(fileStream, image);
            }
        }

        protected void WriteIntAscii(BinaryWriter writer, int value)
        {
            writer.Write(value.ToString(CultureInfo.InvariantCulture).ToCharArray());
        }
    }
}