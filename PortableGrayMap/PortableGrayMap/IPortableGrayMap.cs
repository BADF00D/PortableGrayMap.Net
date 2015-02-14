namespace PortableGrayMap
{
    public interface IPortableGraymap : IPortbleAnymap<byte>
    {
        int MaxValue { get; }
    }
}