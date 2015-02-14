namespace PortableGrayMap
{
    using System;

    internal abstract class PortbleAnymap<TPixel> : IPortbleAnymap<TPixel>
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public TPixel[] Pixels { get; private set; }

        protected PortbleAnymap(int width, int height, TPixel[] pixels)
        {
            if (pixels == null) throw new ArgumentNullException("pixels");
            if (pixels.Length != width*height) throw new ArgumentException("Parameter pixel has wrong size.");

            Width = width;
            Height = height;
            Pixels = pixels;
        }

        public TPixel this[int x, int y]
        {
            get { return Pixels[y*Width + x]; }
            set { Pixels[y * Width + x] = value; }
        }
    }
}