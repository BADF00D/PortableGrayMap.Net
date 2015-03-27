namespace PortableGrayMap.Converter
{
    using System.Drawing;
    using System.Drawing.Imaging;

    internal class PortablePixmapToBitmapConverter : IConverter<IPortablePixmap, Bitmap>
    {
        public Bitmap Convert(IPortablePixmap source)
        {
            var bitmap = new Bitmap(source.Width, source.Height, PixelFormat.Format32bppArgb);

            var scale = 255/source.MaxValue;
            for (var y = 0; y < source.Height; y++)
            {
                for (var x = 0; x < source.Width; x++)
                {
                    var pixel = source[x, y];
                    var color = Color.FromArgb(pixel.Red*scale, pixel.Green*scale, pixel.Blue*scale);
                    bitmap.SetPixel(x, y, color);
                }
            }

            return bitmap;
        }
    }
}