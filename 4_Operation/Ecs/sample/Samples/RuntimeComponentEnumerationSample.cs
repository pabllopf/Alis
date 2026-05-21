// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RuntimeComponentEnumerationSample.cs
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
using Alis.Core.Ecs.Kernel.Events;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    ///     The runtime component enumeration sample class
    /// </summary>
    /// <seealso cref="IEcsSample" />
    internal sealed class RuntimeComponentEnumerationSample : IEcsSample
    {
        /// <summary>
        ///     Gets the value of the key
        /// </summary>
        public string Key => "enumerate-components-runtime";

        /// <summary>
        ///     Gets the value of the title
        /// </summary>
        public string Title => "Runtime Component Enumeration";

        /// <summary>
        ///     Gets the value of the description
        /// </summary>
        public string Description => "Enumerates all components on an entity without knowing generic types at compile time.";

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(3, "runtime", 1.25f);

            Console.WriteLine("Enumerating component values:");
            entity.EnumerateComponents(default(PrintComponentAction));
        }

        /// <summary>
        ///     The print component action
        /// </summary>
        private struct PrintComponentAction : IGenericAction
        {
            /// <summary>
            ///     Invokes the type
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="type">The type</param>
            public void Invoke<T>(ref T type)
            {
                Console.WriteLine($"- {nameof(type)}: {type}");
            }
        }
    }
}