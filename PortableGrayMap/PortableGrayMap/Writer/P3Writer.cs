namespace PortableGrayMap.Writer
{
    using System.IO;
    using System.Text;

    internal class P3Writer : BasicWriter<IPortablePixmap>, IPortablePixmapWriter
    {
        public override void WriteToStream(Stream stream, IPortablePixmap image)
        {
            var writer = new BinaryWriter(stream, Encoding.ASCII);

            writer.Write('P');
            writer.Write('3');
            writer.Write(NewLine);
            WriteIntAscii(writer, image.Width);
            writer.Write(Space);
            WriteIntAscii(writer, image.Height);
            writer.Write(NewLine);
            WriteIntAscii(writer, image.MaxValue);
            writer.Write(NewLine);
            for (var y = 0; y < image.Height; y++)
            {
                for (var x = 0; x < image.Width; x++)
                {
                    var colorToWrite = image[x, y];
                    WriteIntAscii(writer, colorToWrite.Red);
                    writer.Write(Space);
                    WriteIntAscii(writer, colorToWrite.Green);
                    writer.Write(Space);
                    WriteIntAscii(writer, colorToWrite.Blue);
                    writer.Write(Space);
                }
            }
        }
    }
}