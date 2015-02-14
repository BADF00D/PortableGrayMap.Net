namespace PortableGrayMap
{
    internal class PortbaleBitmap : IPortbaleBitmap
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public bool[] Pixels { get; private set; }

        public PortbaleBitmap(int width, int height, bool[] pixels)
        {
            Width = width;
            Height = height;
            Pixels = pixels;
        }
    }
}