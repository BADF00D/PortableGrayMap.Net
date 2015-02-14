namespace PortableGrayMap
{
    /// <summary>
    /// Reader that is able to reader PortableBitmap files. Usually with endings *.pbm.
    /// </summary>
    public interface IPortableBitmapReader : IPortbaleMapReader<IPortbaleBitmap, bool>
    {
    }
}