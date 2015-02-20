namespace PortableGrayMap.Writer
{
    using System.IO;
    using System.Text;

    internal class P1Writer : BasicWriter<IPortbaleBitmap>
    {
        public override void WriteToStream(Stream stream, IPortbaleBitmap image)
        {
            var writer = new BinaryWriter(stream, Encoding.ASCII);

            writer.Write('P');
            writer.Write('1');
            writer.Write(NewLine);
            WriteIntAscii(writer, image.Width);
            writer.Write(Space);
            WriteIntAscii(writer, image.Height);
            writer.Write(NewLine);
            for (var y = 0; y < image.Height; y++)
            {
                for (var x = 0; x < image.Width; x++)
                {
                    writer.Write(image[x, y] ? '1' : '0');
                    writer.Write(Space);
                }
            }
        }
    }
}