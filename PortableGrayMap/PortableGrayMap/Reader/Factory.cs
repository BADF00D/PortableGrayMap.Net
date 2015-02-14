namespace PortableGrayMap.Reader
{
    using System;

    public static class Factory
    {
        private static readonly Lazy<IPortableBitmapReader> P1Reader = new Lazy<IPortableBitmapReader>(() => new P1Reader());
        
        private static readonly Lazy<IPortableBitmapReader> P4Reader = new Lazy<IPortableBitmapReader>(() => new P4Reader());
        
        private static readonly Lazy<IPortableGraymapReader> P2Reader = new Lazy<IPortableGraymapReader>(() => new P2Reader());

        private static readonly Lazy<IPortableBitmapReader> PortableBitmapReader =
            new Lazy<IPortableBitmapReader>(() => new PortableBitmapReader());

        /// <summary>
        /// Gets reader for PortbaleBitmaps with magic string 'P1'.
        /// </summary>
        /// <returns></returns>
        public static IPortableBitmapReader GetReaderForAsciiPortableBitmap()
        {
            return P1Reader.Value;
        }

        /// <summary>
        /// Gets reader for PortbaleBitmaps with magic string 'P4'.
        /// </summary>
        /// <returns></returns>
        public static IPortableBitmapReader GetReaderForBinaryPortableBitmap()
        {
            return P4Reader.Value;
        }

        /// <summary>
        /// Gets reader for PortbaleGraymaps with magic string 'P2'.
        /// </summary>
        /// <returns></returns>
        public static IPortableGraymapReader GetReaderForAsciiPortableGraymap()
        {
            return P2Reader.Value;
        }

        /// <summary>
        /// Returns reader that is able to read PortbaleBitmaps with magic string 'P1' or 'P4'.
        /// </summary>
        /// <returns></returns>
        /// <remarks>Is able to distinguish between P1 and P4  format. But if you use ReadFromStream, 
        /// be sure to provide a stream that can be seeked.</remarks>
        public static IPortableBitmapReader GetPortableBitmapReader()
        {
            return PortableBitmapReader.Value;
        }
    }
}