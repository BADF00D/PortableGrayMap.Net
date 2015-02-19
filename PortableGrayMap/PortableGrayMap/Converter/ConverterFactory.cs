namespace PortableGrayMap.Converter
{
    using System;
    using System.Drawing;

    public static class ConverterFactory
    {
        private static readonly Lazy<IPortableBitmapToConverter<Bitmap>> PortableBitmaptoBitmapConvert =
            new Lazy<IPortableBitmapToConverter<Bitmap>>(() => new PortableBitmapToBitmapConverter());

        public static IPortableBitmapToConverter<T> GetConvertFor<T>()
        {
            if (typeof (T) == typeof (Bitmap))
                return (IPortableBitmapToConverter<T>) PortableBitmaptoBitmapConvert.Value;

            throw new ArgumentException("Unkown destination format.");
        }
    }
}