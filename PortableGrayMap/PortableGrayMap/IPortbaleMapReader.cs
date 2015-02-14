namespace PortableGrayMap
{
    using System.IO;
    using Tanpohp.Annotations.Resharper;

    public interface IPortbaleMapReader<out TMap, out TPixel> where TMap : IPortbleAnymap<TPixel>
    {
        TMap ReadFromStream([NotNull]Stream stream);

        TMap ReadFromFile([NotNull]string path);
    }
}