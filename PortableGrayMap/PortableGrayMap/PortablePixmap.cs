namespace PortableGrayMap
{
    internal class PortablePixmap : PortbleAnymap<RgbPixel>, IPortablePixmap
    {
        public PortablePixmap(int width, int height, RgbPixel[] pixels, ushort maxValue) : base(width, height, pixels)
        {
            MaxValue = maxValue;
        }

        public ushort MaxValue { get; private set; }
    }
}