using System;

namespace Alis.Core.Graphic.Backends
{
    /// <summary>
    /// The illegal class
    /// </summary>
    internal static class Illegal
    {
        /// <summary>
        /// Values
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The exception</returns>
        internal static Exception Value<T>()
        {
            return new IllegalValueException<T>();
        }

        /// <summary>
        /// The illegal value exception class
        /// </summary>
        /// <seealso cref="VeldridException"/>
        internal class IllegalValueException<T> : VeldridException
        {
        }
    }
}
