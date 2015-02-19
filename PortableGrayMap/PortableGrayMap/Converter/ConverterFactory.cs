namespace PortableGrayMap.Converter
{
    using System;
    using System.Drawing;
    using System.Windows.Media.Imaging;

    public static class ConverterFactory
    {
        private static readonly Lazy<IPortableBitmapToConverter<Bitmap>> PbmToBitmapConverter =
            new Lazy<IPortableBitmapToConverter<Bitmap>>(() => new PortableBitmapToBitmapConverter());

        private static readonly Lazy<IPortableBitmapToConverter<BitmapSource>> PbmToBitmapSourceConverter =
            new Lazy<IPortableBitmapToConverter<BitmapSource>>(() => new PortableBitmapToBitmapSourceConverter());

        private static readonly Lazy<IPortableGraymapToConverter<BitmapSource>> PgmToBitmapSourceConverter =
            new Lazy<IPortableGraymapToConverter<BitmapSource>>(() => new PortableGraymapToBitmapSourceConverter());

        private static readonly Lazy<IPortableGraymapToConverter<Bitmap>> PgmToBitmapConverter =
            new Lazy<IPortableGraymapToConverter<Bitmap>>(() => new PortableGraymapToBitmapConverter());

        public static IPortableBitmapToConverter<BitmapSource> ToBitmapSourceConverter
        {
            get { return PbmToBitmapSourceConverter.Value; }
        }

        public static IPortableBitmapToConverter<Bitmap> ToBitmapConverter
        {
            get { return PbmToBitmapConverter.Value; }
        }

        public static IPortableGraymapToConverter<BitmapSource> PortableGraymapToBitmapSourceConverter
        {
            get { return PgmToBitmapSourceConverter.Value; }
        }

        public static IPortableGraymapToConverter<Bitmap> PortableGraymapToBitmapConverter
        {
            get { return PgmToBitmapConverter.Value; }
        }
    }
}