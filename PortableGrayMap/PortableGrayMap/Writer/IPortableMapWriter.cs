namespace PortableGrayMap.Writer
{
    using System.IO;

    public interface IPortableMapWriter<in T>
    {
        /// <summary>
        /// Writes image to stream.
        /// </summary>
        /// <param name="stream">Stream to write to.</param>
        /// <param name="image">Image to write into stream.</param>
        void WriteToStream(Stream stream, T image);

        /// <summary>
        /// Writes image to file. 
        /// </summary>
        /// <param name="pathToFile">File path to write file.</param>
        /// <param name="image">Image to write to file.</param>
        void WriteToFile(string pathToFile, T image);
    }
}