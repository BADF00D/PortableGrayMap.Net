namespace PortableGrayMap
{
    using System;
    using System.IO;

    internal class P1Reader : IPortbaleMapReader<IPortbaleBitmap, bool>
    {
        public IPortbaleBitmap ReadFromStream(Stream stream)
        {
            var reader = new StreamReader(stream);

            return null;
        }

        public IPortbaleBitmap ReadFromFile(string path)
        {
            
            if(!File.Exists(path)) throw new ArgumentException("File does not exists.");
            using (var stream = new FileStream(path, FileMode.Open))
            {
                return ReadFromStream(stream);
            }
        }
    }
}