using System;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The ns range
    /// </summary>
    public struct NSRange
    {
        /// <summary>
        /// The location
        /// </summary>
        public UIntPtr location;
        /// <summary>
        /// The length
        /// </summary>
        public UIntPtr length;

        /// <summary>
        /// Initializes a new instance of the <see cref="NSRange"/> class
        /// </summary>
        /// <param name="location">The location</param>
        /// <param name="length">The length</param>
        public NSRange(UIntPtr location, UIntPtr length)
        {
            this.location = location;
            this.length = length;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NSRange"/> class
        /// </summary>
        /// <param name="location">The location</param>
        /// <param name="length">The length</param>
        public NSRange(uint location, uint length)
        {
            this.location = (UIntPtr)location;
            this.length = (UIntPtr)length;
        }
    }
}