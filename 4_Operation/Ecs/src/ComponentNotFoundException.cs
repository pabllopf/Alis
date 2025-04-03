using System;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The component not found exception class
    /// </summary>
    /// <seealso cref="Exception" />
    internal class ComponentNotFoundException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ComponentNotFoundException" /> class
        /// </summary>
        /// <param name="t">The </param>
        public ComponentNotFoundException(Type t)
            : base($"Component of type {t.FullName} not found")
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ComponentNotFoundException" /> class
        /// </summary>
        /// <param name="message">The message</param>
        public ComponentNotFoundException(string message)
            : base(message)
        {
        }
    }
}