

namespace Alis.Core.Ecs.Kernel.Archetypes
{
    /// <summary>
    ///     The of component class
    /// </summary>
    internal static class OfComponent<T1, T2, T3, T4, T5, T6, T7, T8, TC>
    {
        /// <summary>
        ///     The id
        /// </summary>
        public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6, T7, T8>.Id, Component<TC>.Id);
    }

    /// <summary>
    ///     The of component class
    /// </summary>
    internal static class OfComponent<T1, T2, T3, T4, T5, T6, T7, TC>
    {
        /// <summary>
        ///     The id
        /// </summary>
        public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6, T7>.Id, Component<TC>.Id);
    }

    /// <summary>
    ///     The of component class
    /// </summary>
    internal static class OfComponent<T1, T2, T3, T4, T5, T6, TC>
    {
        /// <summary>
        ///     The id
        /// </summary>
        public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5, T6>.Id, Component<TC>.Id);
    }

    /// <summary>
    ///     The of component class
    /// </summary>
    internal static class OfComponent<T1, T2, T3, T4, T5, TC>
    {
        /// <summary>
        ///     The id
        /// </summary>
        public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4, T5>.Id, Component<TC>.Id);
    }

    /// <summary>
    ///     The of component class
    /// </summary>
    internal static class OfComponent<T1, T2, T3, T4, TC>
    {
        /// <summary>
        ///     The id
        /// </summary>
        public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3, T4>.Id, Component<TC>.Id);
    }

    /// <summary>
    ///     The of component class
    /// </summary>
    internal static class OfComponent<T1, T2, T3, TC>
    {
        /// <summary>
        ///     The id
        /// </summary>
        public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2, T3>.Id, Component<TC>.Id);
    }

    /// <summary>
    ///     The of component class
    /// </summary>
    internal static class OfComponent<T1, T2, TC>
    {
        /// <summary>
        ///     The id
        /// </summary>
        public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2>.Id, Component<TC>.Id);
    }
}