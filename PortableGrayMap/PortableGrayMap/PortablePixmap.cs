namespace PortableGrayMap
{
    internal class PortablePixmap : PortbleAnymap<RgbPixel>, IPortablePixmap
    {
        public PortablePixmap(int width, int height, RgbPixel[] pixels) : base(width, height, pixels)
        {
        }
    }
}