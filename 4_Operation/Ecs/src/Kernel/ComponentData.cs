

using System;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Collections;

namespace Alis.Core.Ecs.Kernel
{
    /// <summary>
    ///     Component metadata
    /// </summary>
    /// <param name="Type">The component type</param>
    /// <param name="Storage">The storage table</param>
    /// <param name="Initer">The initializer delegate</param>
    /// <param name="Destroyer">The destroyer delegate</param>
    /// <remarks>
    ///     Memory layout optimized: 32 bytes total (four references, 8 bytes each)
    ///     Pack = 8 for optimal alignment with reference types on 64-bit architectures
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public record struct ComponentData(Type Type, IdTable Storage, Delegate Initer, Delegate Destroyer);
}