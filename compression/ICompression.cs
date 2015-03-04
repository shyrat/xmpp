// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="ICompression.cs">
//   
// </copyright>
// <summary>
//   Defines the ICompression type.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------
namespace XMPP.compression
{
    /// <summary>
    /// </summary>
    public interface ICompression
    {
        /// <summary>
        /// Called when the stream needs to decompress the incoming data.
        /// </summary>
        /// <param name="data">
        /// The data to be decompressed as a byte array.
        /// </param>
        /// <returns>
        /// A byte array containiong the decompressed data.
        /// </returns>
        byte[] Deflate(byte[] data);

        /// <summary>
        /// </summary>
        /// <param name="data">
        /// </param>
        /// <param name="length">
        /// </param>
        /// <returns>
        /// The <see cref="byte[]"/>.
        /// </returns>
        byte[] Inflate(byte[] data, int length);
    }
}