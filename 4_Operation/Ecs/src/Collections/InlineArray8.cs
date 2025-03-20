using System.Runtime.CompilerServices;

namespace Alis.Core.Ecs.Collections
{
    /// <summary>
    /// The inline array
    /// </summary>
    internal struct InlineArray8<T>
    {
        /// <summary>
        /// The 
        /// </summary>
        public T _0;
        /// <summary>
        /// The 
        /// </summary>
        public T _1;
        /// <summary>
        /// The 
        /// </summary>
        public T _2;
        /// <summary>
        /// The 
        /// </summary>
        public T _3;
        /// <summary>
        /// The 
        /// </summary>
        public T _4;
        /// <summary>
        /// The 
        /// </summary>
        public T _5;
        /// <summary>
        /// The 
        /// </summary>
        public T _6;
        /// <summary>
        /// The 
        /// </summary>
        public T _7;

        /// <summary>
        /// Gets the array
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="index">The index</param>
        /// <returns>The ref</returns>
        public static ref T Get(ref InlineArray8<T> array, int index)
        {
            return ref Unsafe.Add(ref array._0, index);
        }
    }
}