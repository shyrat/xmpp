// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Zlib.cs" company="">
//   
// </copyright>
// <summary>
//   The zlib.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.IO;
using XMPP.compression.sharpziplib.Zip.Compression;
using XMPP.Registries;

namespace XMPP.compression.sharpziplib
{
    /// <summary>
    /// The zlib.
    /// </summary>
    [Compression("zlib", typeof(Zlib))]
    public class Zlib : ICompression
    {
        /// <summary>
        /// The _deflate.
        /// </summary>
        private readonly Deflater _deflate;

        /// <summary>
        /// The _inflate.
        /// </summary>
        private readonly Inflater _inflate;

        /// <summary>
        /// Initializes a new instance of the <see cref="Zlib"/> class.
        /// </summary>
        public Zlib()
        {
            _inflate = new Inflater();
            _deflate = new Deflater();
        }

        #region ICompression Members

        /// <summary>
        /// Called when the stream needs to decompress the incoming data.
        /// </summary>
        /// <param name="data">
        /// The data to be decompressed as a byte array.
        /// </param>
        /// <returns>
        /// A byte array containiong the decompressed data.
        /// </returns>
        public byte[] Deflate(byte[] data)
        {
            int ret;

            _deflate.SetInput(data);
            _deflate.Flush();

            var ms = new MemoryStream();
            do
            {
                var buf = new byte[4096];
                ret = _deflate.Deflate(buf);
                if (ret > 0)
                    ms.Write(buf, 0, ret);
            }
 while (ret > 0);

            return ms.ToArray();
        }

        /// <summary>
        /// </summary>
        /// <param name="data">
        /// </param>
        /// <param name="length">
        /// </param>
        /// <returns>
        /// The <see cref="byte[]"/>.
        /// </returns>
        public byte[] Inflate(byte[] data, int length)
        {
            int ret;

            _inflate.SetInput(data, 0, length);

            var ms = new MemoryStream();
            do
            {
                var buffer = new byte[4096];
                ret = _inflate.Inflate(buffer);
                if (ret > 0)
                    ms.Write(buffer, 0, ret);
            }
 while (ret > 0);

            return ms.ToArray();
        }

        #endregion
    }
}