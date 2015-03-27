namespace PortableGrayMap.Converter
{
    using Tanpohp.Annotations.Resharper;

    public interface IConverter<in TIn, out TOut>
    {
        TOut Convert([NotNull]TIn source);
    }
}