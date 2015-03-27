namespace PortableGrayMap.Converter
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using Tanpohp.Extensions;

    internal class PortableGraymapToBitmapConverter : IConverter<IPortableGraymap, Bitmap>
    {
        public Bitmap Convert(IPortableGraymap source)
        {
            var bitmap = new Bitmap(source.Width, source.Height, PixelFormat.Format32bppArgb);

            var grayValueScale = 255d/source.MaxValue;
            for (var y = 0; y < source.Height; y++)
            {
                for (var x = 0; x < source.Width; x++)
                {
                    var sourceGrayValue = source[x, y];
                    var destinationGrayValue = 255 - (int) ((sourceGrayValue*grayValueScale).Clamp(0, 255));
                    var grayValue = Color.FromArgb(255, destinationGrayValue, destinationGrayValue, destinationGrayValue);
                    bitmap.SetPixel(x, y, grayValue);
                }
            }

            return bitmap;
        }
    }
}