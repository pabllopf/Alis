// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentEvent.cs
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

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Events
{
    /// <summary>
    ///     The component event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1), SkipLocalsInit]
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