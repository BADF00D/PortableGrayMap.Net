namespace PortableGrayMap.Writer
{
    using System;

    public static class WriterFactory
    {
        private static readonly Lazy<IPortableGraymapWriter> P2Writer =
            new Lazy<IPortableGraymapWriter>(() => new P2Writer());

        private static readonly Lazy<IPortableBitmapWriter> P1Writer =
            new Lazy<IPortableBitmapWriter>(() => new P1Writer());

        public static IPortableBitmapWriter AsciiPortableBitmapWriter
        {
            get { return P1Writer.Value; }
        }

        public static IPortableGraymapWriter AsciiPortableGraymapWriter
        {
            get { return P2Writer.Value; }
        }
    }
}