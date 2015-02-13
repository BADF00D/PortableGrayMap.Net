namespace PortableGrayMap
{
    using System.IO;

    public interface IPortbaleMapReader<out TMap, out TPixel> where TMap : IPortbleAnymap<TPixel>
    {
        TMap ReadFromStream(Stream stream);

        TMap ReadFromFile(string path);
    }
}