namespace PortableGrayMap
{
    public interface IPortableGraymap : IPortbleAnymap<ushort>
    {
        ushort MaxValue { get; }
    }
}