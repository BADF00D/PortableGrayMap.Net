namespace PortableGrayMap.Writer
{
    using System.IO;
    using System.Text;

    internal class P6Writer : BasicWriter<IPortablePixmap>, IPortablePixmapWriter
    {
        public override void WriteToStream(Stream stream, IPortablePixmap image)
        {
            var writer = new BinaryWriter(stream, Encoding.ASCII);
            writer.Write('P');
            writer.Write('6');
            writer.Write(NewLine);
            WriteIntAscii(writer, image.Width);
            writer.Write(Space);
            WriteIntAscii(writer, image.Height);
            writer.Write(NewLine);
            WriteIntAscii(writer, image.MaxValue);
            writer.Write(NewLine);
            foreach (var pixel in image.Pixels)
            {
                writer.Write(pixel.Red);
                writer.Write(pixel.Green);
                writer.Write(pixel.Blue);
            }
        }
    }
}