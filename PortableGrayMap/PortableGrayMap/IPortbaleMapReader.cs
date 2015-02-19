namespace PortableGrayMap
{
    using System;
    using System.IO;
    using Tanpohp.Annotations.Resharper;

    public interface IPortbaleMapReader<out TMap> 
    {
        /// <summary>
        /// Reads a image from stream.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown if stream is null.</exception>
        TMap ReadFromStream([NotNull]Stream stream);

        /// <summary>
        /// Read the first image within given file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        TMap ReadFromFile([NotNull]string path);
    }
}