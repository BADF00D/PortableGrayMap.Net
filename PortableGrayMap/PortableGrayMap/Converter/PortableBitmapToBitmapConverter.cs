﻿namespace PortableGrayMap.Converter
{
    using System.Drawing;
    using System.Drawing.Imaging;

    internal class PortableBitmapToBitmapConverter : IConverter<IPortbaleBitmap, Bitmap>
    {
        private readonly Color _white = Color.White; //defined as 0/false
        private readonly Color _black = Color.Black; //defined as 1/true

        public Bitmap Convert(IPortbaleBitmap source)
        {
            var bitmap = new Bitmap(source.Width, source.Height, PixelFormat.Format32bppArgb);

            for (var y = 0; y < source.Height; y++)
            {
                for (var x = 0; x < source.Width; x++)
                {
                    var value = source[x, y] ? _black : _white;
                    bitmap.SetPixel(x, y, value);
                }
            }

            return bitmap;
        }
    }
}