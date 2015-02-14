namespace PortableGrayMap
{
    public interface IPortbleAnymap<TPixel>
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

        /// <summary>
        /// Index for accessing image data directly starting at top left.
        /// </summary>
        /// <param name="x">X coordiante</param>
        /// <param name="y">Y coordinate</param>
        /// <returns></returns>
        TPixel this[int x, int y] { get; set; }
    }
}