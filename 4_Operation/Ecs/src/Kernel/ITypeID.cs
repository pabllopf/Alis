using System;

namespace Alis.Core.Ecs.Kernel
{
    /// <summary>
    ///     The type id interface
    /// </summary>
    public interface ITypeId
    {
        /// <summary>
        ///     Gets the value of the type
        /// </summary>
        internal Type Type { get; }

        /// <summary>
        ///     Gets the value of the value
        /// </summary>
        internal ushort Value { get; }
    }
}