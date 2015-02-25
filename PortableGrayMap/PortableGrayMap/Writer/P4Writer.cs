namespace PortableGrayMap.Writer
{
    using System.IO;
    using System.Linq;
    using System.Text;

    internal class P4Writer : BasicWriter<IPortbaleBitmap>, IPortableBitmapWriter
    {
        public override void WriteToStream(Stream stream, IPortbaleBitmap image)
        {
            var writer = new BinaryWriter(stream, Encoding.ASCII);
            writer.Write('P');
            writer.Write('4');
            writer.Write(NewLine);
            WriteIntAscii(writer, image.Width);
            writer.Write(Space);
            WriteIntAscii(writer, image.Height);
            writer.Write(NewLine);
            var counter = (image.Pixels.Length + 8)/8*8-1;
            var bytes = image.Pixels.Select(b => b ? 1 : 0).Select(i => (byte) (i << (counter--)%8)).ToArray();
            for (var i = 0; i < bytes.Length/8;i+=8)
            {
                var value = bytes.Skip(i).Take(8).Sum(x => x);
                writer.Write((byte)value);
            }
            var sum = bytes.Skip(bytes.Length/8*8).Sum(i => i);
            writer.Write((byte) sum);
        }
    }
}