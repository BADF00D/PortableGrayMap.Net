namespace PortableGrayMap.Writer
{
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using Tanpohp.Extensions;

    internal class P5Writer : BasicWriter<IPortableGraymap>, IPortableGraymapWriter
    {
        public override void WriteToStream(Stream stream, IPortableGraymap image)
        {
            var writer = new BinaryWriter(stream, Encoding.ASCII);
            writer.Write('P');
            writer.Write('5');
            writer.Write(NewLine);
            WriteIntAscii(writer, image.Width);
            writer.Write(Space);
            WriteIntAscii(writer, image.Height);
            writer.Write(NewLine);
            WriteIntAscii(writer, image.MaxValue);
            writer.Write(NewLine);
            if (IsMoreThenOneByteInUse(image))
            {
                WriteImageAsUShort(writer, image);
            }
            else
            {
                WriteImageAsBytes(writer, image);
            }
        }

        private static bool IsMoreThenOneByteInUse(IPortableGraymap image)
        {
            return image.MaxValue > 0xFF || image.Pixels.Any(p => p > 0xFF);
        }

        private static void WriteImageAsUShort(BinaryWriter writer, IPortbleAnymap<ushort> image)
        {
            var pixels = image.Pixels;
            if (IsBigEndianSystem())
            {
                foreach (var pixel in pixels)
                {
                    writer.Write(pixel);
                }
            }
            else
            {
                foreach (var pixel in pixels)
                {
                    //little endian system, we must convert to big endian.
                    writer.Write(pixel.ReverseBytes());
                }
            }
        }

        private static bool IsBigEndianSystem()
        {
            //host order is big-endian. so if there is no change, this is a big-endian system
            return 0xFF == IPAddress.HostToNetworkOrder(0xFF);
        }

        private static void WriteImageAsBytes(BinaryWriter writer, IPortbleAnymap<ushort> image)
        {
            var pixels = image.Pixels;
            foreach (var pixel in pixels)
            {
                writer.Write((byte) pixel);
            }
        }
    }
}