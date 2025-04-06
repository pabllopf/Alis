using System;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The null uniform provider class
    /// </summary>
    /// <seealso cref="IUniformProvider" />
    internal class NullUniformProvider : IUniformProvider
    {
        /// <summary>
        ///     Gets the value of the instance
        /// </summary>
        internal static NullUniformProvider Instance { get; } = new NullUniformProvider();

        /// <summary>
        ///     Gets the uniform
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The</returns>
        public T GetUniform<T>()
        {
            throw new InvalidOperationException("Initialize the world with an IUniformProvider in order to use uniforms");
        }
    }
}