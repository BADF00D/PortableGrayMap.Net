namespace PortableGrayMap
{
    using System;

    public interface IPortableGraymap : IPortbleAnymap<UInt16>
    {
        UInt16 MaxValue { get; }
    }
}