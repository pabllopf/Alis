using System;

namespace Alis.Core.Ecs.Exceptions
{
    /// <summary>
    ///     The component already exists exception class
    /// </summary>
    /// <seealso cref="Exception" />
    public class ComponentAlreadyExistsException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ComponentAlreadyExistsException" /> class
        /// </summary>
        /// <param name="t">The </param>
        public ComponentAlreadyExistsException(Type t)
            : base($"Component of type {t.FullName} already exists on gameObject!")
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ComponentAlreadyExistsException" /> class
        /// </summary>
        /// <param name="message">The message</param>
        public ComponentAlreadyExistsException(string message)
            : base(message)
        {
        }
    }
}