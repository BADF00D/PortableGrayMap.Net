namespace PortableGrayMap.Converter
{
    using System.Drawing;
    using System.Windows.Media.Imaging;

    internal class PortablePixmapToBitmapSourceConverter : IConverter<IPortablePixmap, BitmapSource>
    {
        public BitmapSource Convert(IPortablePixmap source)
        {
            var pixelFormat = System.Windows.Media.PixelFormats.Bgr32;

            var stride = (source.Width*pixelFormat.BitsPerPixel + 7)/8;

            var pixels = new byte[stride*source.Height];

            var scale = 255d/source.MaxValue;
            for (var y = 0; y < source.Height; y++)
            {
                for (var x = 0; x < source.Width; x++)
                {
                    var pixel = source[x, y];
                    var color = Color.FromArgb(255, (byte) (pixel.Red*scale), (byte) (pixel.Green*scale),
                        (byte) (pixel.Blue*scale));

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