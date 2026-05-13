// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:OfComponent.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

namespace Alis.Core.Ecs.Kernel.Archetypes
{
    /// <summary>
    ///     The of component class
    /// </summary>
    /// <typeparam name="T1">The first component type.</typeparam>
    /// <typeparam name="T2">The second component type.</typeparam>
    /// <typeparam name="T3">The third component type.</typeparam>
    /// <typeparam name="T4">The fourth component type.</typeparam>
    /// <typeparam name="T5">The fifth component type.</typeparam>
    /// <typeparam name="T6">The sixth component type.</typeparam>
    /// <typeparam name="T7">The seventh component type.</typeparam>
    /// <typeparam name="T8">The eighth component type.</typeparam>
    /// <typeparam name="TC">The component type.</typeparam>
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
    /// <typeparam name="T1">The first component type.</typeparam>
    /// <typeparam name="T2">The second component type.</typeparam>
    /// <typeparam name="T3">The third component type.</typeparam>
    /// <typeparam name="T4">The fourth component type.</typeparam>
    /// <typeparam name="T5">The fifth component type.</typeparam>
    /// <typeparam name="T6">The sixth component type.</typeparam>
    /// <typeparam name="T7">The seventh component type.</typeparam>
    /// <typeparam name="TC">The component type.</typeparam>
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
    /// <typeparam name="T1">The first component type.</typeparam>
    /// <typeparam name="T2">The second component type.</typeparam>
    /// <typeparam name="T3">The third component type.</typeparam>
    /// <typeparam name="T4">The fourth component type.</typeparam>
    /// <typeparam name="T5">The fifth component type.</typeparam>
    /// <typeparam name="T6">The sixth component type.</typeparam>
    /// <typeparam name="TC">The component type.</typeparam>
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
    /// <typeparam name="T1">The first component type.</typeparam>
    /// <typeparam name="T2">The second component type.</typeparam>
    /// <typeparam name="T3">The third component type.</typeparam>
    /// <typeparam name="T4">The fourth component type.</typeparam>
    /// <typeparam name="T5">The fifth component type.</typeparam>
    /// <typeparam name="TC">The component type.</typeparam>
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
    /// <typeparam name="T1">The first component type.</typeparam>
    /// <typeparam name="T2">The second component type.</typeparam>
    /// <typeparam name="T3">The third component type.</typeparam>
    /// <typeparam name="T4">The fourth component type.</typeparam>
    /// <typeparam name="TC">The component type.</typeparam>
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
    /// <typeparam name="T1">The first component type.</typeparam>
    /// <typeparam name="T2">The second component type.</typeparam>
    /// <typeparam name="T3">The third component type.</typeparam>
    /// <typeparam name="TC">The component type.</typeparam>
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
    /// <typeparam name="T1">The first component type.</typeparam>
    /// <typeparam name="T2">The second component type.</typeparam>
    /// <typeparam name="TC">The component type.</typeparam>
    internal static class OfComponent<T1, T2, TC>
    {
        /// <summary>
        ///     The id
        /// </summary>
        public static readonly int Index = GlobalWorldTables.ComponentIndex(Archetype<T1, T2>.Id, Component<TC>.Id);
    }
}