namespace PortableGrayMap
{
    internal class PortbaleBitmap : IPortbaleBitmap
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public bool[] Pixels { get; private set; }

        public bool this[int x, int y]
        {
            get { return Pixels[y * Width + x]; }
            set { Pixels[y*Width + x] = value; }
        }

        public PortbaleBitmap(int width, int height, bool[] pixels)
        {
            Width = width;
            Height = height;
            Pixels = pixels;
        }
    }
}