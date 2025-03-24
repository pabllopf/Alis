using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


namespace Alis.Core.Ecs.Core.Events
{
    /// <summary>
    ///     The component event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1 )]
    [SkipLocalsInit]
    internal struct ComponentEvent()
    {
        /// <summary>
        ///     The normal event
        /// </summary>
        internal Event<ComponentID> NormalEvent = new();

        /// <summary>
        ///     The generic event
        /// </summary>
        internal GenericEvent GenericEvent = null;

        /// <summary>
        ///     Gets the value of the has listeners
        /// </summary>
        public bool HasListeners => NormalEvent.HasListeners || (GenericEvent is { } e && e.HasListeners);
    }
}