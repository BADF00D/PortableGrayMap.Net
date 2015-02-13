namespace PortableGrayMap
{
    public interface IPortbleAnymap<out TPixel>
    {
        /// <summary>
        /// Width of image. 
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Height of image.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Pixels from left to right and top to down.
        /// </summary>
        TPixel[] Pixels { get; }
    }
}