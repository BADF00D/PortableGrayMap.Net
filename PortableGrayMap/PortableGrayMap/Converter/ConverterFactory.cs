namespace PortableGrayMap.Converter
{
    using System;
    using System.Drawing;
    using System.Windows.Media.Imaging;

    public static class ConverterFactory
    {
        private static readonly Lazy<IConverter<IPortbaleBitmap, Bitmap>> PbmToBitmapConverter =
            new Lazy<IConverter<IPortbaleBitmap, Bitmap>>(() => new PortableBitmapToBitmapConverter());

        private static readonly Lazy<IConverter<IPortbaleBitmap, BitmapSource>> PbmToBitmapSourceConverter =
            new Lazy<IConverter<IPortbaleBitmap, BitmapSource>>(() => new PortableBitmapToBitmapSourceConverter());

        private static readonly Lazy<IConverter<IPortableGraymap,BitmapSource>> PgmToBitmapSourceConverter =
            new Lazy<IConverter<IPortableGraymap, BitmapSource>>(() => new PortableGraymapToBitmapSourceConverter());

        private static readonly Lazy<IConverter<IPortableGraymap, Bitmap>> PgmToBitmapConverter =
            new Lazy<IConverter<IPortableGraymap,Bitmap>>(() => new PortableGraymapToBitmapConverter());

        public static IConverter<IPortbaleBitmap, BitmapSource> ToBitmapSourceConverter
        {
            get { return PbmToBitmapSourceConverter.Value; }
        }

        public static IConverter<IPortbaleBitmap, Bitmap> ToBitmapConverter
        {
            get { return PbmToBitmapConverter.Value; }
        }

        public static IConverter<IPortableGraymap, BitmapSource> PortableGraymapToBitmapSourceConverter
        {
            get { return PgmToBitmapSourceConverter.Value; }
        }

        public static IConverter<IPortableGraymap, Bitmap> PortableGraymapToBitmapConverter
        {
            get { return PgmToBitmapConverter.Value; }
        }
    }
}