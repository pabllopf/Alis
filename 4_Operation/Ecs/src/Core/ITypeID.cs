using System;

namespace Alis.Core.Ecs.Core
{
    /// <summary>
    /// The type id interface
    /// </summary>
    internal interface ITypeID
    {
        /// <summary>
        /// Gets the value of the type
        /// </summary>
        internal Type Type { get; }
        /// <summary>
        /// Gets the value of the value
        /// </summary>
        internal ushort Value { get; }
    }
}
