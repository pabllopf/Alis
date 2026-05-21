

using System;

namespace Alis.Core.Aspect.Math.Matrix
{
    /// <summary>
    ///     The exception thrown when an attempt is made to access a matrix element using an invalid row or column index.
    /// </summary>
    /// <seealso cref="Exception" />
    public class CustomIndexOutOfRangeException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CustomIndexOutOfRangeException" /> class with no error message.
        /// </summary>
        public CustomIndexOutOfRangeException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CustomIndexOutOfRangeException" /> class with a specified error message describing the invalid matrix index.
        /// </summary>
        /// <param name="invalidMatrixIndex">The error message that describes the invalid matrix index.</param>
        public CustomIndexOutOfRangeException(string invalidMatrixIndex) : base(invalidMatrixIndex)
        {
        }
    }
}
