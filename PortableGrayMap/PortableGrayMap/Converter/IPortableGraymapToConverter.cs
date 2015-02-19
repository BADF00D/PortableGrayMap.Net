namespace PortableGrayMap.Converter
{
    using Tanpohp.Annotations.Resharper;

    public interface IPortableGraymapToConverter<out T>
    {
        T ConvertFrom([NotNull] IPortableGraymap source);
    }
}