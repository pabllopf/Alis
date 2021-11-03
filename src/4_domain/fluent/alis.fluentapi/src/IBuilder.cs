using System;

namespace Alis.FluentApi
{
    /// <summary>
    /// The builder interface
    /// </summary>
    public interface IBuilder<T>
    {
        /// <summary>
        /// Builders
        /// </summary>
        /// <returns>The</returns>
        public static T Builder()
        {
            return (T) Activator.CreateInstance(typeof(T), true);
        }
    }
}