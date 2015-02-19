namespace PortableGrayMap
{
    internal class PortableGraymap : PortbleAnymap<ushort>, IPortableGraymap
    {
        public PortableGraymap(int width, int height, ushort[] pixels, ushort maxValue) : base(width, height, pixels)
        {
            MaxValue = maxValue;
        }

        public ushort MaxValue { get; private set; }
    }
}