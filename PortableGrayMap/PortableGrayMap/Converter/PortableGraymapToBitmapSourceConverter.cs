namespace PortableGrayMap.Converter
{
    using System.Drawing;
    using System.Windows.Media.Imaging;
    using Tanpohp.Extensions;

    internal class PortableGraymapToBitmapSourceConverter : IPortableGraymapToConverter<BitmapSource>
    {
        public BitmapSource ConvertFrom(IPortableGraymap source)
        {
            var pixelFormat = System.Windows.Media.PixelFormats.Bgr32;

            var stride = (source.Width*pixelFormat.BitsPerPixel + 7)/8;

            var pixels = new byte[stride*source.Height];

            var grayValueScale = 255d/source.MaxValue;
            for (var y = 0; y < source.Height; y++)
            {
                for (var x = 0; x < source.Width; x++)
                {
                    var sourceGrayValue = source[x, y];
                    var destinationGrayValue = 255 - (int) ((sourceGrayValue*grayValueScale).Clamp(0, 255));
                    var color = Color.FromArgb(255, destinationGrayValue, destinationGrayValue, destinationGrayValue);

                    var baseIndex = x*4 + y*stride;
                    pixels[baseIndex] = color.B;
                    pixels[baseIndex + 1] = color.G;
                    pixels[baseIndex + 2] = color.R;
                    pixels[baseIndex + 3] = color.A;
                }
            }

            return BitmapSource.Create(source.Width, source.Height, 96, 96, pixelFormat, null, pixels, stride);
        }
    }
}