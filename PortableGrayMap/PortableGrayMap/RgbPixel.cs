namespace PortableGrayMap
{
    public class RgbPixel
    {
        public byte Red, Green, Blue;

        public RgbPixel(int rgb)
        {
            Red = (byte)((rgb >> 16) | 0xFF);
            Green = (byte)((rgb >> 8) | 0xFF);
            Blue = (byte)(rgb | 0xFF);
        }
    }
}