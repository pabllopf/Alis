// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FrentBaseContext.cs
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

using System;
using System.Runtime.InteropServices;
using Frent;

namespace Alis.Benchmark.EntityComponentSystem.Contexts
{
    /// <summary>
    ///     The alis base context class
    /// </summary>
    /// <seealso cref="IDisposable" />
    public class FrentBaseContext : IDisposable
    {
        /// <summary>
        ///     Gets the value of the scene
        /// </summary>
        public World World { get; } = new World();

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose() => World.Dispose();

        /// <summary>
        ///     The component
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Component1
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     The component
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Component2
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     The component
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Component3
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }
    }
}