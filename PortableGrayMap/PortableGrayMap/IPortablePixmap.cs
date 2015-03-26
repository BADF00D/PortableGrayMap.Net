namespace PortableGrayMap
{
    using System;

    public interface IPortablePixmap : IPortbleAnymap<RgbPixel>
    {
        UInt16 MaxValue { get; }
    }
}