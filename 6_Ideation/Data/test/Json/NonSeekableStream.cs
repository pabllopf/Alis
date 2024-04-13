using System.IO;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    /// The non seekable stream class
    /// </summary>
    /// <seealso cref="MemoryStream"/>
    public class NonSeekableStream : MemoryStream
    {
        /// <summary>
        /// Gets the value of the can seek
        /// </summary>
        public override bool CanSeek => false;
    }
}