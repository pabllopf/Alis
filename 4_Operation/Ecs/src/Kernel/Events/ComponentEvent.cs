

using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Kernel.Events
{
    /// <summary>
    ///     The component event
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: GenericEvent reference (8 bytes) + Event struct (24 bytes)
    ///     Total: 32 bytes
    ///     Pack = 8 for optimal alignment with reference types
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct ComponentEvent()
    {
        /// <summary>
        ///     The generic event
        /// </summary>
        internal GenericEvent GenericEvent = null;

        /// <summary>
        ///     The normal event
        /// </summary>
        internal Event<ComponentId> NormalEvent = new Event<ComponentId>();

        /// <summary>
        ///     Gets the value of the has listeners
        /// </summary>
        public bool HasListeners => NormalEvent.HasListeners || (GenericEvent is { } e && e.HasListeners);
    }
}