namespace PortableGrayMap.Reader
{
    using System;

    public static class Factory
    {
        public static Lazy<IPortableBitmapReader> P1Reader = new Lazy<IPortableBitmapReader>(() => new P1Reader());
        public static Lazy<IPortableBitmapReader> P4Reader = new Lazy<IPortableBitmapReader>(() => new P4Reader());
        public static Lazy<IPortableGraymapReader> P2Reader = new Lazy<IPortableGraymapReader>(()=> new P2Reader()); 
    }
}