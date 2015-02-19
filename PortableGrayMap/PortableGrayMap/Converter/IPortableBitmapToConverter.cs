namespace PortableGrayMap.Converter
{
    using Tanpohp.Annotations.Resharper;

    public interface IPortableBitmapToConverter<out T>
    {
        T ConvertFrom([NotNull]IPortbaleBitmap source);
    }
}