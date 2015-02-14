namespace PortableGrayMap
{
    internal class PortbaleBitmap : PortbleAnymap<bool>, IPortbaleBitmap
    {
        public PortbaleBitmap(int width, int height, bool[] pixels) : base(width, height, pixels)
        {
        }
    }
}