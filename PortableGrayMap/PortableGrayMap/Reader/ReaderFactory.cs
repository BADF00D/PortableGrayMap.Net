namespace PortableGrayMap.Reader
{
    using System;

    public static class ReaderFactory
    {
        private static readonly Lazy<IPortableBitmapReader> P1Reader =
            new Lazy<IPortableBitmapReader>(() => new P1Reader());

        private static readonly Lazy<IPortableBitmapReader> P4Reader =
            new Lazy<IPortableBitmapReader>(() => new P4Reader());

        private static readonly Lazy<IPortableGraymapReader> P2Reader =
            new Lazy<IPortableGraymapReader>(() => new P2Reader());

        private static readonly Lazy<IPortablePixmapReader> P3Reader =
            new Lazy<IPortablePixmapReader>(() => new P3Reader());

        private static readonly Lazy<IPortableGraymapReader> P5Reader =
            new Lazy<IPortableGraymapReader>(() => new P5Reader());

        private static readonly Lazy<IPortablePixmapReader> P6Reader =
            new Lazy<IPortablePixmapReader>(() => new P6Reader());

        private static readonly Lazy<IPortableBitmapReader> P1AndP4Reader =
            new Lazy<IPortableBitmapReader>(() => new PortableBitmapReader());

        private static readonly Lazy<IPortableGraymapReader> P2AndP5Reader =
            new Lazy<IPortableGraymapReader>(() => new PortableGraymapReader());

        /// <summary>
        /// Gets reader for PortbaleBitmaps with magic string 'P1'.
        /// </summary>
        /// <returns></returns>
        public static IPortableBitmapReader AsciiPortableBitmapReader
        {
            get { return P1Reader.Value; }
        }

        /// <summary>
        /// Gets reader for PortbalePixmap with magic string 'P3'.
        /// </summary>
        /// <returns></returns>
        public static IPortablePixmapReader AsciiPortablePixmapReader
        {
            get { return P3Reader.Value; }
        }

        /// <summary>
        /// Gets reader for PortbaleBitmaps with magic string 'P4'.
        /// </summary>
        /// <returns></returns>
        public static IPortableBitmapReader BinaryPortableBitmapReader
        {
            get { return P4Reader.Value; }
        }

        /// <summary>
        /// Gets reader for PortbaleGraymaps with magic string 'P2'.
        /// </summary>
        /// <returns></returns>
        public static IPortableGraymapReader AsciiPortableGraymapReader
        {
            get { return P2Reader.Value; }
        }

        /// <summary>
        /// Gets reader for PortbaleGraymaps with magic string 'P5'.
        /// </summary>
        /// <returns></returns>
        public static IPortableGraymapReader BinaryPortableGraymapReader
        {
            get { return P5Reader.Value; }
        }

        /// <summary>
        /// Gets reader for PortbalePixmaps with magic string 'P6'.
        /// </summary>
        /// <returns></returns>
        public static IPortablePixmapReader BinaryPortablePixmapReader
        {
            get { return P6Reader.Value; }
        }

        /// <summary>
        /// Returns reader that is able to read PortbaleBitmaps with magic string 'P1' or 'P4'.
        /// </summary>
        /// <returns></returns>
        /// <remarks>Is able to distinguish between P1 and P4  format. But if you use ReadFromStream, 
        /// be sure to provide a stream that can be seeked.</remarks>
        public static IPortableBitmapReader PortableBitmapReader
        {
            get { return P1AndP4Reader.Value; }
        }

        /// <summary>
        /// Returns reader that is able to read PortbaleGraymaps with magic string 'P2' or 'P5'.
        /// </summary>
        /// <returns></returns>
        /// <remarks>Is able to distinguish between P2 and P5 format. But if you use ReadFromStream, 
        /// be sure to provide a stream that can be seeked.</remarks>
        public static IPortableGraymapReader GetPortableGraymapReader
        {
            get { return P2AndP5Reader.Value; }
        }
    }
}