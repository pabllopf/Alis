// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CreateFromObjectsSample.cs
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

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    ///     The create from objects sample class
    /// </summary>
    /// <seealso cref="IEcsSample" />
    internal sealed class CreateFromObjectsSample : IEcsSample
    {
        /// <summary>
        ///     Gets the value of the key
        /// </summary>
        public string Key => "create-from-objects";

        /// <summary>
        ///     Gets the value of the title
        /// </summary>
        public string Title => "Create From Objects";

        /// <summary>
        ///     Gets the value of the description
        /// </summary>
        public string Description => "Creates entities from a runtime object array using CreateFromObjects.";

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            object[] first = [1, "runtime", 2.5f];
            object[] second = [2, "object array", 9.8f];

            GameObject entityA = scene.CreateFromObjects(first);
            GameObject entityB = scene.CreateFromObjects(second);

            Console.WriteLine($"Entity A -> int={entityA.Get<int>()}, string={entityA.Get<string>()}, float={entityA.Get<float>()}");
            Console.WriteLine($"Entity B -> int={entityB.Get<int>()}, string={entityB.Get<string>()}, float={entityB.Get<float>()}");
        }
    }
}