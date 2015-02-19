namespace PortableGrayMap.Converter
{
    using System;
    using System.Drawing;
    using System.Windows.Media.Imaging;

    public static class ConverterFactory
    {
        private static readonly Lazy<IPortableBitmapToConverter<Bitmap>> PortableBitmapToBitmapConvert =
            new Lazy<IPortableBitmapToConverter<Bitmap>>(() => new PortableBitmapToBitmapConverter());

        private static readonly Lazy<IPortableBitmapToConverter<BitmapSource>> PortableBitmapToBitmapSourceConverter =
            new Lazy<IPortableBitmapToConverter<BitmapSource>>(() => new PortableBitmapToBitmapSourceConverter());


        public static IPortableBitmapToConverter<BitmapSource> ToBitmapSourceConverter
        {
            get { return PortableBitmapToBitmapSourceConverter.Value; }
        }

        public static IPortableBitmapToConverter<Bitmap> ToBitmapConverter
        {
            get { return PortableBitmapToBitmapConvert.Value; }
        }
    }
}