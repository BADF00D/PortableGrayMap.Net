﻿namespace PortableGrayMap.Converter
{
    using System;
    using System.Drawing;
    using System.Windows.Media.Imaging;

    public static class ConverterFactory
    {
        private static readonly Lazy<IConverter<IPortbaleBitmap, Bitmap>> PbmToBitmapConverter =
            new Lazy<IConverter<IPortbaleBitmap, Bitmap>>(() => new PortableBitmapToBitmapConverter());

        private static readonly Lazy<IPortableBitmapToConverter<BitmapSource>> PbmToBitmapSourceConverter =
            new Lazy<IPortableBitmapToConverter<BitmapSource>>(() => new OneWayPortableBitmapToBitmapSourceConverter());

        private static readonly Lazy<IPortableGraymapToConverter<BitmapSource>> PgmToBitmapSourceConverter =
            new Lazy<IPortableGraymapToConverter<BitmapSource>>(() => new OneWayPortableGraymapToBitmapSourceConverter());

        private static readonly Lazy<IPortableGraymapToConverter<Bitmap>> PgmToBitmapConverter =
            new Lazy<IPortableGraymapToConverter<Bitmap>>(() => new OneWayPortableGraymapToBitmapConverter());

        public static IPortableBitmapToConverter<BitmapSource> ToBitmapSourceConverter
        {
            get { return PbmToBitmapSourceConverter.Value; }
        }

        public static IConverter<IPortbaleBitmap, Bitmap> ToBitmapConverter
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