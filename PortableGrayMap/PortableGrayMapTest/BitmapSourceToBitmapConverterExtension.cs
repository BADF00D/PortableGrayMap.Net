namespace PortableGrayMapTest
{
    using System.Drawing;
    using System.IO;
    using System.Windows.Media.Imaging;

    public static class BitmapSourceToBitmapConverterExtension
    {
        public static Bitmap ConvertToBitmap(this BitmapSource source)
        {
            using (var memoryStream = new MemoryStream())
            {
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(source));
                encoder.Save(memoryStream);

                memoryStream.Seek(0, SeekOrigin.Begin);

                return new Bitmap(memoryStream);
            }
        }
    }
}