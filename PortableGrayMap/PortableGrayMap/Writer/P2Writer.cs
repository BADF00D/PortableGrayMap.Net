namespace PortableGrayMap.Writer
{
    using System.IO;
    using System.Text;

    internal class P2Writer : BasicWriter<IPortableGraymap>
    {
        public override void WriteToStream(Stream stream, IPortableGraymap image)
        {
            var writer = new BinaryWriter(stream, Encoding.ASCII);

            writer.Write('P');
            writer.Write('2');
            writer.Write(NewLine);
            WriteIntAscii(writer, image.Width);
            writer.Write(Space);
            WriteIntAscii(writer, image.Height);
            writer.Write(Space);
            WriteIntAscii(writer, image.MaxValue);
            writer.Write(NewLine);
            for (var y = 0; y < image.Height; y++)
            {
                for (var x = 0; x < image.Width; x++)
                {
                    WriteIntAscii(writer, image[x,y]);
                    writer.Write(Space);
                }
            }
        }
    }
}