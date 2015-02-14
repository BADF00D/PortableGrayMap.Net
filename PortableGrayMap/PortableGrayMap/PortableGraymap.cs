namespace PortableGrayMap
{
    internal class PortableGraymap : PortbleAnymap<byte>, IPortableGraymap
    {
        public PortableGraymap(int width, int height, byte[] pixels, int maxValue) : base(width, height, pixels)
        {
            MaxValue = maxValue;
        }

        public int MaxValue { get; private set; }
    }
}